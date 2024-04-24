using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class IconDragger : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Inventory inventory;
    public ItemManager itemManager;
    public int itemId;

    private InventoryManager inventoryManager;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform, nextPos;
    private int totalColls = 0;
    private int startId, tileId;
    private bool started;


    private void Awake()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = gameObject.transform.parent.gameObject.GetComponent<Canvas>();
        Debug.Log("inited");
        started = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Picked icon item up");
        canvasGroup.alpha = 0.5f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (nextPos != null && totalColls > 0) {
            gameObject.GetComponent<RectTransform>().anchoredPosition = nextPos.anchoredPosition;

            // swap two inventory values;
            int tmp = inventory.Items[startId];
            inventory.Items[startId] = inventory.Items[tileId];
            inventory.Items[tileId] = tmp;
        } 
        else {
            Vector3 offset = new Vector3(0, -1, 0);
            Instantiate(itemManager.itemPrefab[inventory.Items[startId]], GameObject.FindGameObjectWithTag("Player").gameObject.transform.position + offset, Quaternion.identity);
            inventory.Items[startId] = -1;
            Destroy(gameObject);
        }

        // update the gui
        inventoryManager.RefreshInventory();
        nextPos = null;
    }

    public void OnTriggerEnter2D(Collider2D coll) 
    {
        Debug.Log("triggered");
        if (started == false) {
            startId = coll.gameObject.GetComponent<TileDragger>().id;
            started = true;
            totalColls++;
            return;
        }

        if (coll.gameObject.GetComponent<TileDragger>() != null) {
            tileId = coll.gameObject.GetComponent<TileDragger>().id;
            nextPos = coll.gameObject.GetComponent<RectTransform>();
            totalColls++;
        }
    }

    public void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<TileDragger>() != null) {
            totalColls--;
        }
    }
}