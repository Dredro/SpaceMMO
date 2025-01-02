using Interactions;
using NPC;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Dialog
{
    public class EnhanceDialog : MonoBehaviour, IDialog
    {
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private TextMeshProUGUI body;
        [SerializeField] private Image armorDecoratorIcon;
        [SerializeField] private GameObject panel;

        [SerializeField] private ArmorDecorator armorDecorator;
        private Enhancer _npc;
        private InteractionData? _interactionData;

        public string Title
        {
            get => title.text;
            set => title.text = value;
        }

        public string Body
        {
            get => body.text;
            set => body.text = value;
        }

        private void Start()
        {
            if (armorDecorator != null)
            {
                armorDecoratorIcon.sprite = armorDecorator.icon;
            }

            panel.SetActive(false);
            _npc = GetComponentInParent<Enhancer>();
        }

        public void Confirm()
        {
            if (!_interactionData.HasValue || _npc == null) return;

            if (_interactionData.Value.Source is Player player &&
                player.inventory.items[0] is Armor armor)
            {
                _npc.DecorateArmor(player.inventory, armor);
            }

            Hide();
        }

        public void Cancel()
        {
            Hide();
        }

        public void Show(InteractionData data)
        {
            if (_npc == null) return;

            _interactionData = data;
            Title = _npc.Name;
            Body = _npc.BodyText;

            panel.SetActive(true);
        }

        public void Hide()
        {
            _interactionData = null;
            panel.SetActive(false);
        }
    }
}