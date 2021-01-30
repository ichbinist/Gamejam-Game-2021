using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChatManager : Singleton<ChatManager>
{
    [HideInInspector]
    public UnityEvent onStartCommunication = new UnityEvent();
}
