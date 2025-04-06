using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "ScriptableObjects/Item")]
public class item : ScriptableObject
{
  public string itemName; // 物品名称
    [TextArea]
    public string itemDescription; // 物品描述
    public Sprite itemIcon; // 物品图标
    public int itemCount; // 物品数量

    public bool equip; // 是否可装备

    // 添加其他属性和方法，根据需要扩展物品类
}
