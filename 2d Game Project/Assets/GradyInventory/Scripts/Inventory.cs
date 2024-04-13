using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory")]
public class Inventory : ScriptableObject
{
    // contains what the user actual is holding
    public int[] Items;

    public int[] Armor;

    public int[] Weapons;

    public int[] Tools;
}
