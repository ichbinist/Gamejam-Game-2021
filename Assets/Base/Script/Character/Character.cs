using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Character : MonoBehaviour
{
    public CharacterType CharacterType;
    [Range(0,100f)]
    public float Speed;
    [HideInInspector]
    public UnityEvent OnInteractionKeyPressed = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnCharacterInitialized = new UnityEvent();
    [HideInInspector]
    public InteractableBase CurrentInteractable;

    public bool IsControlable;

    public GameObject Graphics;

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