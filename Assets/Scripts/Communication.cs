﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Communication : MonoBehaviour
{
    public CommunicationType communicationType;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ChatManager.Instance.onStartCommunication.Invoke(communicationType, null);
        }
    }   
}
