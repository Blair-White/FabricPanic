using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricDrop : MonoBehaviour
{
    public int BasketType;
    private List<GameObject> fabricList;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<FabricScript>().FabricType == BasketType)
        {
            collision.gameObject.GetComponent<DragController>().isColliding = true;
            fabricList.Add(collision.gameObject);

        }
    }
    void Update()
    {
        if (fabricList.Count > 0)
        {
            GameObject lastItem = fabricList[fabricList.Count - 1];
            if (lastItem.GetComponent<DragController>().canBeDropped == true)
            {
                lastItem.SetActive(false);
                lastItem.GetComponent<DragController>().isColliding = false;
            }
        }
    }
}
