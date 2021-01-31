using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractable : ColliderInteractable
{

    public Sprite itemSprite;

    public override void Do()
    {
        base.Do();
        itemSprite = GetComponentInChildren<SpriteRenderer>().sprite;
        InventoryManager.Instance.onItemCollected.Invoke(itemSprite, ItemType.Hammer);
        Destroy(gameObject);

    }
}
