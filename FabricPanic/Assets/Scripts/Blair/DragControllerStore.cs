using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragControllerStore : MonoBehaviour
{
  
    private FabricDrop fabricDrop;
    private Vector3 mOffset;
    private float mZCoord;

    public bool isColliding, isMouseUp, canBeDropped;
    private bool isPlaced;
    public Vector3 startPosition;
    public GameObject currentHoverObject, previousObject, dropEffect;
 
    void Start()
    {
        isColliding = false;
        isMouseUp = true;
        canBeDropped = false;
       
    }
    void OnMouseDown()
    {
        isPlaced = false;
        isMouseUp = false;
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        //Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        
    }
    void OnMouseUp()
    {
        isMouseUp = true;
        this.GetComponent<Outline>().enabled = false;
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
        this.GetComponent<Outline>().enabled = true;
        if (!canBeDropped)
        {
            transform.position = GetMouseAsWorldPoint() + mOffset + new Vector3(-1,0,0);
            if (!isPlaced)
            {

                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    Transform objectHit = hit.transform;

                    if (objectHit.gameObject.tag == "PlacingBox")
                    {
                        this.GetComponent<Outline>().OutlineWidth = 3;
                        this.GetComponent<Outline>().OutlineColor = Color.green;
                        currentHoverObject = objectHit.gameObject;
                    }
                    else
                    {
                        this.GetComponent<Outline>().OutlineWidth = 2;
                        this.GetComponent<Outline>().OutlineColor = Color.white;
                        currentHoverObject = null;
                    }
                }
            }
        }
        else
        {
        
        }
        
    }

    private void FixedUpdate()
    {
        
    }
    void Update ()
    {
        //if (isPlaced) return;
        if (currentHoverObject != null) { currentHoverObject.GetComponent<Collider>().enabled = true; }
        if (isColliding && isMouseUp)
        {
            canBeDropped = true;
            isColliding = false;
            isPlaced = true;
        
        }
        

        if(!isMouseUp)
        {
            if (previousObject != null) { previousObject.GetComponent<Collider>().enabled = true; }
            if (currentHoverObject!= null) { currentHoverObject.GetComponent<Collider>().enabled = true; }
        }

        if(isMouseUp)
        {
            if (currentHoverObject == null)
            {
                canBeDropped = false;
                if (this.GetComponent<DeliveryBolt>().isFinishedMove)
                    transform.position = Vector3.MoveTowards(transform.position, startPosition, .25f);
            }

            if (currentHoverObject != null)
            {
                canBeDropped = false;
                transform.position = Vector3.MoveTowards(transform.position, currentHoverObject.transform.position, .25f);
                if (Vector3.Distance(this.transform.position, currentHoverObject.transform.position) < .001f)
                {
                    startPosition = currentHoverObject.transform.position;
                    currentHoverObject.GetComponent<Collider>().enabled = false;
                    previousObject = currentHoverObject;
                    GameObject o = Instantiate(dropEffect); o.transform.position = currentHoverObject.transform.position;
                    o.GetComponent<KillEffect>().ps.GetComponent<ParticleSystem>().transform.position = o.transform.position;
                    currentHoverObject = null; this.GetComponent<Outline>().OutlineWidth = 2;    
                }
                else
                {
                    
                }
            }

        }
            
        
    }
}