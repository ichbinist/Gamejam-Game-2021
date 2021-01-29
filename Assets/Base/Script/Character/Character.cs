using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    public CharacterType CharacterType;

    [HideInInspector]
    public UnityEvent OnInteractionKeyPressed = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnCharacterInitialized = new UnityEvent();

    public InteractableBase CurrentInteractable;

    private void Awake()
    {
        if(CharacterType == CharacterType.Player)
        {
            gameObject.AddComponent<CharacterInteractionController>();
            gameObject.AddComponent<CharacterMovementController>();

            OnCharacterInitialized.Invoke();
        }
    }

    private void OnEnable()
    {
        if (!Managers.Instance) return;
        CharacterManager.Instance.GetPlayer = this;
    }

    private void OnDisable()
    {
        if (!Managers.Instance) return;
        CharacterManager.Instance.GetPlayer = null;
    }
}

public enum CharacterType
{
    none,
    Player,
    AI
}