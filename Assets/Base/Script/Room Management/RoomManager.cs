using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class RoomManager : Singleton<RoomManager>
{
    public RoomEvent OnRoomEnter = new RoomEvent();
    public RoomEvent OnRoomExit = new RoomEvent();
    [HideInInspector]
    public Room CurrentRoom;
}
public class RoomEvent : UnityEvent<int> { }