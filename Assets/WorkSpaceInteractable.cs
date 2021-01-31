using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkSpaceInteractable : ColliderInteractable
{
    public ItemType CorrectType;

    public Sprite CollectedItemSprite;
    public ItemType CollectedItemType;
    public List<QAData> qADatas;

    public override void Do()
    {
        base.Do();
        if (!(InventoryManager.Instance.SelectedItem == CorrectType))
        {
            return;
        }
        

        InventoryManager.Instance.onItemUsed.Invoke(InventoryManager.Instance.SelectedItem);
        
        if (GetComponent<NPCCommunication>() == null)
        {
            Destroy(gameObject);
            InventoryManager.Instance.onItemCollected.Invoke(CollectedItemSprite, CollectedItemType);
        }
        else
        {
            ChatManager.Instance.onStartCommunication.Invoke(CommunicationType.Insight, qADatas);
            GameObject.Find("chatBoxPanel").GetComponent<ChatBoxPanelController>().HideChat();
        }          
    }

}
