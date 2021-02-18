using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragControllerStore : MonoBehaviour
{
  
    private FabricDrop fabricDrop;
    private Vector3 mOffset;
    private float mZCoord;

    public bool isColliding, isMouseUp, canBeDropped;
    public bool isRushRequest, isStorePlaceable;
    private bool isPlaced;
    void Start()
    {
        isColliding = false;
        isMouseUp = true;
        canBeDropped = false;
        
    }
    void OnMouseDown()
    {
        isMouseUp = false;
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        //Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }
    void OnMouseUp()
    {
        isMouseUp = true;
    }
    private Vector3 GetMouseAsWorldPoint()
    {
        //Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        //z coordinate of game object on screen
        mousePoint.z = mZCoord;

        //Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        if (!canBeDropped)
        { 
            transform.position = GetMouseAsWorldPoint() + mOffset;
        }
    }
    void Update ()
    {
        if (isPlaced) return;

        if(isStorePlaceable)
        {
            if (isColliding && isMouseUp)
            {
                canBeDropped = true;
                isColliding = false;
                isPlaced = true;
            }
            else
            {
                canBeDropped = false;
            }


        }

    }
}