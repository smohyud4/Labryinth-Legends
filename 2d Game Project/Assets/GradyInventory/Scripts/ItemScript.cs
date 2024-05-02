using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class ItemScript : MonoBehaviour
{
    public Inventory inventory;
    public int id;
    private int keyId = 4;
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
        int keycount = 0;
        for (int i = 0; i != inventory.Items.Length; ++i) {
            if (inventory.Items[i] == keyId) {
                keycount++;
                if (keycount == 2) {
                    SceneManager.LoadScene("Rooms/Scenes/BOSS/1");
                }
            }
            if (inventory.Items[i] == -1) {
                inventory.Items[i] = id;
                Destroy(gameObject);
                break;
            }
        }
    }
}
