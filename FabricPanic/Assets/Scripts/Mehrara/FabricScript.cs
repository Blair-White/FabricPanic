using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricScript : MonoBehaviour
{
    public int FabricType;
    public Vector3 initialPos;
    public bool resetPos;
    void Start()
    {
        resetPos = false;
        initialPos = this.transform.localPosition;
    }
    void Update()
    {
        if (resetPos)
        {
            this.transform.localPosition = new Vector3(initialPos.x, initialPos.y, initialPos.z);
            resetPos = false;
        }
    }
}
