using Interactions;
using InventorySystem;
using NPC;
using TMPro;
using UI.Inventory;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace UI.Dialog
{
    /// <summary>
    /// Manages the Enhance Dialog UI, handling user interactions for enhancing armor.
    /// </summary>
    public class EnhanceDialog : MonoBehaviour, IDialog
    {
        [Header("UI Elements")]
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private TextMeshProUGUI body;
        [SerializeField] private GameObject panel;
        [SerializeField] private UITemporarySlot userSlot;
        [SerializeField] private Button confirmButton;
        [SerializeField] private Button decorateFireResistanceOptionButton;
        private Enhancer _npc;
        private InteractionData _interactionData;
        private DecorateOptions _selectedDecorationOption = DecorateOptions.FireResistance;

        /// <summary>
        /// Gets or sets the title text of the dialog.
        /// </summary>
        public string Title
        {
            get => title.text;
            set => title.text = value;
        }

        /// <summary>
        /// Gets or sets the body text of the dialog.
        /// </summary>
        public string Body
        {
            get => body.text;
            set => body.text = value;
        }

        /// <summary>
        /// Initializes the dialog by hiding the panel and retrieving the Enhancer component.
        /// </summary>
        private void Start()
        {
            panel.SetActive(false);
            _npc = GetComponentInParent<Enhancer>();
            if(confirmButton == null) Debug.LogError("Confirm button is null!");
            if(decorateFireResistanceOptionButton == null) Debug.LogError("Decorate fireresistance button is null!");
        }

        /// <summary>
        /// Confirms the enhancement action, applying the selected decoration option to the player's armor.
        /// </summary>
        public void Confirm()
        {
            if (_interactionData.Source == null || _npc == null)
                return;

            if (_interactionData.Source is Player player)
            {
                if (userSlot.itemInSlot == null)
                {
                    Body = "Give me your armor to upgrade";
                    return;
                }
                var itemId = userSlot.itemInSlot.itemId;
                var playerInventory = InventoryController.Instance.GetInventory(player.inventory.id);
                Armor armor = null;
                foreach (var item in playerInventory.items)
                {
                    if (item is Armor a && item.itemData.id == itemId )
                    {
                        armor = a;
                        break;
                    }
                }

                if (armor != null)
                {
                    switch (_selectedDecorationOption)
                    {
                        case DecorateOptions.FireResistance:
                            _npc.DecorateArmorWithFireResistance(player.inventory, armor);
                            break;
                        default:
                            Body = "Select decorate option!";
                            break;
                    }
                }
            }

            Hide();
        }

        /// <summary>
        /// Cancels the enhancement action and hides the dialog.
        /// </summary>
        public void Cancel()
        {
            Hide();
        }

        /// <summary>
        /// Displays the dialog with the provided interaction data.
        /// </summary>
        /// <param name="data">The interaction data to display.</param>
        public void Show(InteractionData data)
        {
            if (_npc == null)
                return;

            _interactionData = data;
            Title = _npc.Name;
            Body = _npc.BodyText;
            panel.SetActive(true);
            confirmButton.onClick.AddListener(Confirm);
            decorateFireResistanceOptionButton.onClick.AddListener(OnDecorateArmorWithFireResistanceClick);
        }

        /// <summary>
        /// Hides the dialog and clears the interaction data.
        /// </summary>
        public void Hide()
        {
            _interactionData.Source = null;
            userSlot.OnHide();
            panel.SetActive(false);
            confirmButton.onClick.RemoveListener(Confirm);
            decorateFireResistanceOptionButton.onClick.RemoveListener(OnDecorateArmorWithFireResistanceClick);
        }

        /// <summary>
        /// Sets the selected decoration option to Fire Resistance.
        /// </summary>
        public void OnDecorateArmorWithFireResistanceClick()
        {
            Body = "So you wanna decorate item with fire resistance?";
            _selectedDecorationOption = DecorateOptions.FireResistance;
        }
    }

    /// <summary>
    /// Defines the available decoration options for armor enhancement.
    /// </summary>
    public enum DecorateOptions
    {
        FireResistance
    }
}
