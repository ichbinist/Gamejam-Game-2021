using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [HideInInspector]
    public int RoomID;
    public GameObject Graphics;
    public bool IsStartingRoom;
    private void Awake()
    {
        RoomID = gameObject.GetInstanceID();
    }

    private void OnEnable()
    {
        if (!Managers.Instance) return;

        if (IsStartingRoom)
        {
            RoomManager.Instance.CurrentRoom = this;
        }
        HideGraphics(RoomManager.Instance.CurrentRoom.RoomID);
        RoomManager.Instance.OnRoomEnter.AddListener(HideGraphics);
    }
    private void OnDisable()
    {
        if (!Managers.Instance) return;
        RoomManager.Instance.OnRoomEnter.RemoveListener(HideGraphics);
    }

    private void HideGraphics(int roomID)
    {
        if (roomID == RoomID) { Graphics.SetActive(true); } else { Graphics.SetActive(false); }      
    }
}