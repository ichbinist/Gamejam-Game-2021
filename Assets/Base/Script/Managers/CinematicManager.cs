using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CinematicManager : Singleton<CinematicManager>
{
    public CinematicEvent OnCinematicStarted = new CinematicEvent();
    public CinematicEvent OnCinematicFinished = new CinematicEvent();

    private void OnEnable()
    {
      if(!Managers.Instance) return;

    }

    private void OnDisable()
    {
      if(!Managers.Instance) return;

    }
}

public class CinematicEvent : UnityEvent<InteractableBase> { }