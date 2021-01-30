using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractionController : MonoBehaviour
{
    private Character character;
    public Character Character { get { return (character == null) ? character = GetComponent<Character>() : character; } }

    private void OnEnable()
    {
      if(!Managers.Instance) return;

    }

    private void OnDisable()
    {
      if(!Managers.Instance) return;

    }

    private void Update()
    {
        if (!Character.CurrentInteractable)
            return;

        if (Input.GetKeyDown("e"))
        {
            Character.OnInteractionKeyPressed.Invoke();
        }
    }
}
