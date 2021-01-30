using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCommunication : ColliderInteractable
{
    public CommunicationType communicationType;
    public override void Do()
    {
        base.Do();
        ChatManager.Instance.onStartCommunication.Invoke(communicationType);
    }

}

public enum CommunicationType
{
    NPC,
    Insight
}
