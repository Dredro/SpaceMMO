using System;
using Interactions;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI.Dialog
{
    public class BasicDialog : MonoBehaviour,IDialog
    {
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private TextMeshProUGUI body;
        
        public string Title { get; set; }
        public string Body { get; set; }
        
        private void Start()
        {
            title.text = Title;
            body.text = Body;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void OnStartInteract(InteractionData data)
        {
           Show();
        }

        public void OnEndInteract(InteractionData data)
        {
            Hide(); 
        }
    }
}