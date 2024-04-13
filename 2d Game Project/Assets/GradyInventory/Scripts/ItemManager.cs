using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItemManager", menuName = "ItemManager")]
public class ItemManager : ScriptableObject
{
    public GameObject[] itemIcon;
    public GameObject[] itemPrefab;
}
