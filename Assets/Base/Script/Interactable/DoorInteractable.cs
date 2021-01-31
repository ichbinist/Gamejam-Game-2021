using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : ColliderInteractable
{
    public DoorInteractable LinkedDoor;
    public Room AttachedRoom;

    private void OnEnable()
    {
        if (!Managers.Instance) return;
        CinematicManager.Instance.OnCinematicFinished.AddListener(ChangeRoom);
    }

    private void OnDisable()
    {
        if (!Managers.Instance) return;
        CinematicManager.Instance.OnCinematicFinished.RemoveListener(ChangeRoom);
    }

    public override void Do()
    {
        base.Do();
        CinematicManager.Instance.OnCinematicStarted.Invoke(this);
        CharacterManager.Instance.GetPlayer.IsControlable = false;
    }

    public void ChangeRoom(InteractableBase interactableBase)
    {
        if (interactableBase != this)
            return;
        if (RoomManager.Instance.CurrentRoom != null)
            RoomManager.Instance.OnRoomExit.Invoke(RoomManager.Instance.CurrentRoom.RoomID);
        RoomManager.Instance.OnRoomEnter.Invoke(AttachedRoom.RoomID);
        TeleportPlayer();
        CharacterManager.Instance.GetPlayer.IsControlable = true;
    }

    public void TeleportPlayer()
    {
        if(LinkedDoor != null)
            CharacterManager.Instance.GetPlayer.transform.position = LinkedDoor.transform.position;
    }
}
