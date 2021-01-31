using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkSpaceInteractable : ColliderInteractable
{

    public Sprite CollectedItemSprite;
    public ItemType CollectedItemType;

    public override void Do()
    {
        base.Do();
        if (!(InventoryManager.Instance.SelectedItem == ItemType.Hammer))
        {
            Debug.Log("Selected Item is not a Hammer, you have " + InventoryManager.Instance.SelectedItem + " in your hands");
            return;
        }

        InventoryManager.Instance.onItemUsed.Invoke(InventoryManager.Instance.SelectedItem);
        InventoryManager.Instance.onItemCollected.Invoke(CollectedItemSprite, CollectedItemType);


        Destroy(gameObject);
    }

}
