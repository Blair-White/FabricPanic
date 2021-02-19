using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryBolt : MonoBehaviour
{
    public List<Vector3> WaypointsReceived;
    public bool isFinishedMove;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

        if (WaypointsReceived.Count > 0)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, WaypointsReceived[0], 0.08f);
            if(Vector3.Distance(this.transform.position, WaypointsReceived[0]) < 0.00000001f)
            {
                WaypointsReceived.RemoveAt(0);
            }
        }
        else
        {
            isFinishedMove = true;
        }
    }
}
