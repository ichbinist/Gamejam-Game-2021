using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class InventoryTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Transform InventoryHolder;
    public Vector2 InventoryStartPosition;

    private void Start()
    {
        InventoryStartPosition = InventoryHolder.position;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        InventoryHolder.DOMoveY(InventoryStartPosition.y - 110f, 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InventoryHolder.DOMoveY(InventoryStartPosition.y, 0.3f);
    }
}
