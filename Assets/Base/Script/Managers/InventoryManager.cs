using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{

    public ItemType SelectedItem;

    [HideInInspector]
    public ItemCollected onItemCollected = new ItemCollected();

    [HideInInspector]
    public ItemUsed onItemUsed = new ItemUsed();
}

public class ItemCollected : UnityEvent<Sprite, ItemType>
{

}

public class ItemUsed : UnityEvent<ItemType>
{

}

public enum ItemType
{
    None,
    Hammer,
    NeedleAndThread,
    Battery,
    LaserBeam
}