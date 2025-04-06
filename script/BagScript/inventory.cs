using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInventory", menuName = "ScriptableObjects/Inventory")]
public class inventory : ScriptableObject
{
  public List<item> itemList = new List<item>();
}
