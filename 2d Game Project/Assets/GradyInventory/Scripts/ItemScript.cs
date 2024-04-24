using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemScript : MonoBehaviour
{
    public Inventory inventory;
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.Rotate(0, 5, 0, Space.Self);
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        for (int i = 0; i != inventory.Items.Length; ++i) {
            if (inventory.Items[i] == -1) {
                inventory.Items[i] = id;
                Destroy(gameObject);
                break;
            }
        }
    }
}
