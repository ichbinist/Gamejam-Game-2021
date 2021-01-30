using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChatManager : Singleton<ChatManager>
{
    [HideInInspector]
    public ChatEvent onStartCommunication = new ChatEvent();    

}

public class ChatEvent : UnityEvent<CommunicationType, List<QAData>>
{

}
