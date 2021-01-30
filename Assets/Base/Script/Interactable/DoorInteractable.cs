using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : ColliderInteractable
{
    public Room AttachedRoom;
    public override void Do()
    {
        base.Do();
        if(RoomManager.Instance.CurrentRoom != null)
            RoomManager.Instance.OnRoomExit.Invoke(RoomManager.Instance.CurrentRoom.RoomID);
        RoomManager.Instance.OnRoomEnter.Invoke(AttachedRoom.RoomID);           
    }
}
