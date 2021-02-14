using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{
    public List<GameObject> inventoryList;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "InventoryObject" )
        {
           collision.gameObject.GetComponent<DragController>().isColliding = true;
           inventoryList.Add(collision.gameObject);
        }

        if (collision.gameObject.name == "DeliveryBolt")
        {
            collision.gameObject.GetComponent<DragController>().isColliding = true;
            inventoryList.Add(collision.gameObject);
        }
    }
    void Update()
    {
        if (inventoryList.Count > 0)
        {
            GameObject lastItem = inventoryList[inventoryList.Count - 1];
            if(lastItem.GetComponent<DragController>().canBeDropped == true)
            {
                // Assuming we only want 3 items on the shelf
                if (inventoryList.Count <= 3)
                {
                    lastItem.transform.position = new Vector3(1 + 2 * (inventoryList.Count - 1), transform.position.y, transform.position.z);
                    Debug.Log("Dropped at" + lastItem.transform.position);
                    lastItem.GetComponent<DragController>().isColliding = false;
                }
            }
        }
    }
}