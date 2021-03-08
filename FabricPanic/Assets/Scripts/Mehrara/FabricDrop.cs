using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricDrop : MonoBehaviour
{
    public int BasketType;
    public int score = 0;
   // private List<GameObject> fabricList;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<FabricScript>().FabricType == BasketType)
        {
            collision.gameObject.GetComponent<DragController>().isColliding = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<FabricScript>().FabricType == BasketType)
        {
            collision.gameObject.GetComponent<DragController>().isColliding = false;
        }
    }
}
