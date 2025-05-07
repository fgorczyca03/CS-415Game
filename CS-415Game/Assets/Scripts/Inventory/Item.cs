using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //[SerializeField]
    public string itemName;

    //[SerializeField]
    public Sprite itemSprite;
    
    [TextArea]
    //[SerializeField]
    public string itemDescription;

    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            inventoryManager.AddItem(itemName, itemSprite, itemDescription);
            Destroy(gameObject);
        }
    }
}
