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
        InventoryManager.Instance.onItemUsed.AddListener(DeleteYourself);
    }

    public void onClickEvent()
    {
        Debug.Log("Item clicked. Type: " + type.ToString());
        InventoryManager.Instance.SelectedItem = type;
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(onClickEvent);
    }
    public void DeleteYourself(ItemType itemType)
    {
        if(type == itemType)
        {
            InventoryManager.Instance.onItemUsed.RemoveListener(DeleteYourself);
            Destroy(gameObject);
            InventoryManager.Instance.SelectedItem = ItemType.None;
        }
        
    }
}
