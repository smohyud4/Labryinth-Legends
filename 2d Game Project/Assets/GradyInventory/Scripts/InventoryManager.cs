using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject[] tiles;
    public Inventory inventory;
    public ItemManager itemManager;
    public bool ClearInventory;

    private GameObject overlay;
    private Canvas canvas;
    private bool isOpen;
    private List<GameObject> renderedObjects;

    // Start is called before the first frame update
    void Start()
    {
        overlay = GameObject.FindGameObjectWithTag("InventoryOverlay");
        for (int i = 0; i < tiles.Length; i++) 
        {
            tiles[i] = overlay.transform.GetChild(i).gameObject;
        }
        canvas = GameObject.Find("Canvas").gameObject.GetComponent<Canvas>();
        overlay.SetActive(false);


        if (ClearInventory == true) {
            for (int i = 0; i != inventory.Items.Length; ++i) {
                inventory.Items[i] = -1;
            }
        }
        isOpen = false;
        renderedObjects = new List<GameObject>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            isOpen = !isOpen;
            overlay.SetActive(isOpen);

            
            // loads/destroys ui icons at apropriate inventory spot
            if (isOpen) LoadInventory();
            else DestroyInventory();
        }
        else if (Input.GetKeyDown(KeyCode.X)) {
            inventory.health -= 5;
        }
        else if (Input.GetKeyDown(KeyCode.R)) {
            inventory.health = 100;
        }
    }


    public void RefreshInventory()
    {
        DestroyInventory();
        LoadInventory();
    }

    void LoadInventory()
    {
        
        for (int i = 0; i != inventory.Items.Length; ++i) {
            if (inventory.Items[i] != -1) {
                renderedObjects.Add(Instantiate(itemManager.itemIcon[inventory.Items[i]], tiles[i].transform.position, Quaternion.identity, overlay.transform.parent));
            }
        }
    }

    void DestroyInventory()
    {
        for (int i = 0; i != renderedObjects.Count; ++i) {
            Destroy(renderedObjects[i]);
        }
        renderedObjects.Clear();
    }
}
