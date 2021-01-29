using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : Singleton<CharacterManager>
{
    public Character GetPlayer;
    private void OnEnable()
    {
      if(!Managers.Instance) return;

    }

    private void OnDisable()
    {
      if(!Managers.Instance) return;

    }
}
