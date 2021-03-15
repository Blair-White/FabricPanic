using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This lowkey is used as basket script
public class FabricDrop : MonoBehaviour
{
    public int BasketType;
    public int fabricsTotal; // number of fabrics existing of THIS basket pattern
    public int fabricsCollected = 0;
    public int score = 0;
    public bool isCompleted;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<FabricScript>().FabricType == BasketType)
        {
            collision.gameObject.GetComponent<DragController>().isColliding = true;
        }
        else
        { 
            collision.gameObject.GetComponent<DragController>().wrongColliding = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<FabricScript>().FabricType == BasketType)
        {
            collision.gameObject.GetComponent<DragController>().isColliding = false;
            collision.gameObject.GetComponent<DragController>().wrongColliding = false;
        }
    }
    void Update()
    {
        if (fabricsCollected == fabricsTotal)
        {
            isCompleted = true;
        }
    }
}
