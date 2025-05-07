using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float interactRange = 4.0f; // Range within which the player can interact
    public string doorOpen, doorClose;
    Item itemInfo;
    GameObject items;
    private InventoryManager inventoryManager;
    public LayerMask pickUp;
    public Transform cam;

    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        items = GameObject.FindWithTag("Item");
        itemInfo = items.GetComponent<Item>();
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, interactRange))
        {
            if(hit.collider.gameObject.tag == "Door")
            {
                GameObject doorParent = hit.collider.transform.root.gameObject;
                Animator doorAnim = doorParent.GetComponent<Animator>();
                if(Input.GetKeyDown(KeyCode.E))
                {
                    // Closes the door
                    if(doorAnim.GetCurrentAnimatorStateInfo(0).IsName(doorOpen))
                    {
                        doorAnim.ResetTrigger("Open");
                        doorAnim.SetTrigger("Close");
                    }
                    // Opens the door
                    if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName(doorClose))
                    {
                        doorAnim.ResetTrigger("Close");
                        doorAnim.SetTrigger("Open");
                    }
                }
            }
            /*if(Input.GetKeyDown(KeyCode.E))//hit.collider.gameObject.tag == "Item")
            {
                //if(Physics.Raycast(cam.position, cam.forward, out hit, interactRange, pickUp))
                Debug.Log(gameObject);
                //inventoryManager.AddItem(itemInfo.itemName, itemInfo.itemSprite, itemInfo.itemDescription);
                //Destroy(itemInfo.gameObject);
            }*/
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
        /*RaycastHit hit;
        active = Physics.Raycast(playerCam.position, playerCam.forward, out hit, interactRange);
        if (Input.GetKeyUp(KeyCode.E) && active == true)
        {*/
        //Debug.Log("door check");
        //openCheck.DoorInteract();
        //}
    //}
}
