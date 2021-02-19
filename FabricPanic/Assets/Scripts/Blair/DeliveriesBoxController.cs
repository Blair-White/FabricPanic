using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveriesBoxController : MonoBehaviour
{
    [SerializeField]
    private int BoltCountInBox;
    [SerializeField]
    private GameObject BoltObject;
    private GameObject WaypointHolder;
    public List<Vector3> PopOutWaypoints;
    public bool isActivated, isBusyGivingFabric, isTutorial;
    private Vector3 startingBoltPoint;

    // Start is called before the first frame update
    void Start()
    {
       WaypointHolder = this.transform.GetChild(0).gameObject;
       for(int i = 0; i < 8; i++)
       {
            PopOutWaypoints.Add(WaypointHolder.transform.GetChild(i).transform.position);
       }
        startingBoltPoint = PopOutWaypoints[7];
    }

    // Update is called once per frame
    void Update()
    {
        if(isActivated && !isBusyGivingFabric)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.name == "DeliveriesBox")
                    {
                        if (BoltCountInBox > 0)
                        {
                            CreateBoltFromBox();
                            BoltCountInBox--;
                            isBusyGivingFabric = true;
                            if(isTutorial)
                            {
                                GameObject pointer = GameObject.Find("pointer"); pointer.SetActive(false);
                            }
                        }
                    }
                }

            }


        }

    }

    void CreateBoltFromBox()
    {
        GameObject mBoltCreated = Instantiate(BoltObject);
        mBoltCreated.transform.position = this.transform.position;
        foreach (var waypoint in PopOutWaypoints)
        {
            mBoltCreated.GetComponent<DeliveryBolt>().WaypointsReceived.Add(waypoint);
            mBoltCreated.GetComponent<DragControllerStore>().startPosition = startingBoltPoint;
        }
    }
}
