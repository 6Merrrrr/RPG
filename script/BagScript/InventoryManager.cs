using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager instance; // 单例实例
    public inventory myBag; // 玩家背包

    public GameObject slotGrid; // 背包格子
    public Slot slotPrefab; // 背包格子预制体
    public Text itemInfo; // 物品信息文本

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 保持背包管理器在场景切换时不被销毁
        }
        else
        {
            Destroy(gameObject); // 如果已经存在实例，则销毁当前对象
        }
    }
    private void OnEnable()
    {
        RefreshItem(); // 刷新物品列表
    }

    public static void CreateNewItem(item Item)
    {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform); // 创建新的槽位
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform); // 设置父物体为背包格子
        newItem.slotNum.text = Item.itemCount.ToString(); // 设置物品数量文本
        newItem.slotItem = Item; // 设置槽位物品
        newItem.slotImage.sprite = Item.itemIcon; // 设置槽位图标
    }
    public static void RefreshItem()
    {
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject); // 销毁所有槽位
        }
        for (int i = 0; i < instance.myBag.itemList.Count; i++)
        { 
          CreateNewItem(instance.myBag.itemList[i]); // 创建新的槽位
        }
    }
}