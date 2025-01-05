using Interactions;
using NPC;
using TMPro;
using UnityEngine;

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
                Armor armor = null;
                foreach (var item in player.inventory.items)
                {
                    if (item is Armor a)
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
        }

        /// <summary>
        /// Hides the dialog and clears the interaction data.
        /// </summary>
        public void Hide()
        {
            _interactionData.Source = null;
            panel.SetActive(false);
        }

        /// <summary>
        /// Sets the selected decoration option to Fire Resistance.
        /// </summary>
        public void OnDecorateArmorClick()
        {
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
