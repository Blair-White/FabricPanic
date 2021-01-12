using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{
    public List<GameObject> inventoryList;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "InventoryObject")
        {
            collision.gameObject.GetComponent<DragController>().isColliding = true;

           if(inventoryList.Count<=3) 
           {
                collision.gameObject.transform.position = new Vector3( 2 * (inventoryList.Count),transform.position.y, transform.position.z);
                inventoryList.Add(collision.gameObject);
                //Debug.Log(collision.gameObject.transform.position);
           }
        }
    }
}
