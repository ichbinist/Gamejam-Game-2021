using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : ColliderInteractable
{
    public DoorInteractable LinkedDoor;
    public Room AttachedRoom;

    public override void Do()
    {
        base.Do();
        if(RoomManager.Instance.CurrentRoom != null)
            RoomManager.Instance.OnRoomExit.Invoke(RoomManager.Instance.CurrentRoom.RoomID);
        RoomManager.Instance.OnRoomEnter.Invoke(AttachedRoom.RoomID);
        TeleportPlayer();
    }

    public void TeleportPlayer()
    {
        if(LinkedDoor != null)
            CharacterManager.Instance.GetPlayer.transform.position = LinkedDoor.transform.position;
    }
}
