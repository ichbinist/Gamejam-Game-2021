using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class RoomManager : MonoBehaviour
{
    public RoomEvent OnRoomEnter = new RoomEvent();
    public RoomEvent OnRoomExit = new RoomEvent();

    private void OnEnable()
    {
      if(!Managers.Instance) return;

    }

    private void OnDisable()
    {
      if(!Managers.Instance) return;

    }
}
public class RoomEvent : UnityEvent<int> { }