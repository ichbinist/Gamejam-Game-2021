using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    [HideInInspector]
    public ItemCollected onItemCollected = new ItemCollected();
}

public class ItemCollected : UnityEvent<Sprite, ItemType>
{

}

public enum ItemType
{
    Hammer,
    NeedleAndThread,
    Battery,
    LaserBeam
}