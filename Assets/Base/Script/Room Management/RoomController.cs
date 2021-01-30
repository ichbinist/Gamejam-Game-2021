using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    private Room room;
    public Room Room { get { return (room == null) ? room = GetComponent<Room>() : room; } }
    private void OnEnable()
    {
        if (!Managers.Instance) return;

        RoomManager.Instance.OnRoomEnter.AddListener(SetCurrentRoom);
    }

    private void OnDisable()
    {
        if (!Managers.Instance) return;

        RoomManager.Instance.OnRoomEnter.RemoveListener(SetCurrentRoom);
    }


    private void SetCurrentRoom(int roomID)
    {
        if (Room.RoomID == roomID)
            RoomManager.Instance.CurrentRoom = Room;
    }
}
