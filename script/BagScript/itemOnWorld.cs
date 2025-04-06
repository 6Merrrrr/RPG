using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class itemOnWorld : MonoBehaviour
{
    public item thisitem;
    public inventory playerInventory;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
          AddNewItem();
          Destroy(gameObject); // 销毁物品
        }
    }

    public void AddNewItem()
    {
        if(!playerInventory.itemList.Contains(thisitem))
        {
            playerInventory.itemList.Add(thisitem);
             // 创建新的物品槽位
            InventoryManager.CreateNewItem(thisitem);
        }
        else
        {
           thisitem.itemCount++;
        }
        InventoryManager.RefreshItem();
    }
}

