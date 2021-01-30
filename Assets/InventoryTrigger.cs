using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class InventoryTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Transform InventoryHolder;
    bool isInventoryDown = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isInventoryDown) return;
        GetComponent<BoxCollider2D>().enabled = false;
        InventoryHolder.DOMoveY(InventoryHolder.position.y - 110f, 0.2f).OnStart(() =>
        {
            isInventoryDown = true;
        }).OnComplete(() =>
        {
            GetComponent<BoxCollider2D>().enabled = true;
        });
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isInventoryDown) return;
        GetComponent<BoxCollider2D>().enabled = false;

        InventoryHolder.DOMoveY(InventoryHolder.position.y + 110f, 0.2f).OnStart(() =>
        {
            isInventoryDown = false;
        }).OnComplete(() =>
        {
            GetComponent<BoxCollider2D>().enabled = true;
        });
    }
}
