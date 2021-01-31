using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InventoryTrigger : MonoBehaviour
{

    public Transform InventoryHolder;
    public Vector2 InventoryStartPosition;

    private void Start()
    {
        InventoryStartPosition = InventoryHolder.localPosition;
    }

    private void Update()
    {
        if (Screen.height - 100f < Input.mousePosition.y)
        {
            InventoryHolder.DOLocalMoveY(InventoryStartPosition.y - 110f, 0.3f);
        }
        else if(InventoryHolder.localPosition.y == InventoryStartPosition.y - 110f)
        {
            InventoryHolder.DOLocalMoveY(InventoryStartPosition.y, 0.3f);
        }
    }
}
