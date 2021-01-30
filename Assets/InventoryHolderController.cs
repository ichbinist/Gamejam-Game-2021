using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class InventoryHolderController : MonoBehaviour
{
    public GameObject InventoryItem;
    public Transform InventoryHolder;
    public GameObject InventoryTrigger;

    private void OnEnable()
    {
        if (!Managers.Instance) return;
        InventoryManager.Instance.onItemCollected.AddListener(onItemCollectedListener);

    }

    private void OnDisable()
    {
        if (!Managers.Instance) return;
        InventoryManager.Instance.onItemCollected.AddListener(onItemCollectedListener);

    }

    private void onItemCollectedListener(Sprite itemSprite, ItemType type)
    {
        // inventory'e ilgili sprite'ı ekle
        Instantiate(InventoryItem, InventoryHolder).GetComponent<ButtonClickController>().Initialize(type);
        InventoryItem.GetComponent<Image>().sprite = itemSprite;

        // inventory'i aşağı kaydır ve kullanıcıya göster
        InventoryHolder.DOMoveY(InventoryHolder.position.y - 110f, 0.2f);
        //InventoryTrigger.DOMoveY(InventoryHolder.position.y - 110f, 0.2f);

        // Inventory Triggerini disable et.
        InventoryTrigger.GetComponent<BoxCollider2D>().enabled = false;

        // 2 saniye sonunda inventory'i eski haline getir.
        StartCoroutine(startCO());

    }

    

    IEnumerator startCO()
    {
        yield return new WaitForSeconds(2f);
        InventoryHolder.DOMoveY(InventoryHolder.position.y + 110f, 0.2f);
        InventoryTrigger.GetComponent<BoxCollider2D>().enabled = true;
        //InventoryTrigger.DOMoveY(InventoryHolder.position.y + 110f, 0.2f);

    }
}
