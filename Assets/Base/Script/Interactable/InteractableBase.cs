using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class InteractableBase : MonoBehaviour, IInteractable
{
    public UnityEvent OnInteracted = new UnityEvent();
    
    private void OnEnable()
    {
      if(!Managers.Instance) return;

    }

    private void OnDisable()
    {
      if(!Managers.Instance) return;

    }

    public void Do()
    {
        OnInteracted.Invoke();
    }

    public abstract void Interact();
    public abstract void Escape();

}
