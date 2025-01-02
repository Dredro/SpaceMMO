using System;
using Interactions;
using NPC;
using UI.Dialog;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractor interactor))
        {
            var data = new InteractionData(player, "");
            interactor.OnStartInteract(data);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IInteractor interactor))
        {
            var data = new InteractionData(player, "");
            interactor.OnEndInteract(data);
        }
    }
}
