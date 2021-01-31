using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCommunication : ColliderInteractable
{
    public CommunicationType communicationType;
    public List<QAData> Conversation = new List<QAData>();
    bool isChatDone;
    public override void Do()
    {
        base.Do();
        if (isChatDone)
            return;
        ChatManager.Instance.onStartCommunication.Invoke(communicationType, Conversation);
        CharacterManager.Instance.GetPlayer.IsControlable = false;
        isChatDone = true;
    }
}

public enum CommunicationType
{
    NPC,
    Insight
}
