using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class InteractableBase : MonoBehaviour, IInteractable
{
    public UnityEvent OnInteracted = new UnityEvent();
    public bool IsOneTimeInteractable;
    private void ListenInteractable()
    {
      if(!Managers.Instance) return;
        CharacterManager.Instance.GetPlayer.OnInteractionKeyPressed.AddListener(Do);
    }

    private void UnlistenInteractable()
    {
      if(!Managers.Instance) return;
        CharacterManager.Instance.GetPlayer.OnInteractionKeyPressed.RemoveListener(Do);
    }

    public virtual void Do()
    {
        if (CharacterManager.Instance.GetPlayer.CurrentInteractable == this)
            OnInteracted.Invoke();
        Debug.Log(gameObject.name + "'s Do() function called");

    }

    public virtual void Interact()
    {
        CharacterManager.Instance.GetPlayer.CurrentInteractable = this;
        ListenInteractable();
    }

    public virtual void Escape()
    {
        if (CharacterManager.Instance.GetPlayer.CurrentInteractable == this)
            CharacterManager.Instance.GetPlayer.CurrentInteractable = null;

        UnlistenInteractable();
    }
}
