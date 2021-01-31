using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCommunication : ColliderInteractable
{
    public CommunicationType communicationType;
    public List<QAData> Conversation = new List<QAData>();

    public override void Do()
    {
        base.Do();
        ChatManager.Instance.onStartCommunication.Invoke(communicationType, Conversation);
        CharacterManager.Instance.GetPlayer.IsControlable = false;
    }
}

public enum CommunicationType
{
    NPC,
    Insight
}
