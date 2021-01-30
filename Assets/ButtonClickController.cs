using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickController : MonoBehaviour
{

    public Button button;
    public ItemType type;

    public void Initialize(ItemType type)
    {
        this.type = type;
        button.onClick.AddListener(onClickEvent);
    }

    public void onClickEvent()
    {
        Debug.Log("Item clicked. Type: " + type.ToString());
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(onClickEvent);
    }
}
