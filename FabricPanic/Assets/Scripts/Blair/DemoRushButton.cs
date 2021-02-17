using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoRushButton : MonoBehaviour
{
    public GameObject world, rushrequest;
    private bool onOff;
    public void ActivateRushRequest()
    {
        if(!onOff)
        {
            world.SetActive(false);
            rushrequest.SetActive(true);
            onOff = true;
            return;
        }

        if (onOff)
        {
            world.SetActive(true);
            rushrequest.SetActive(false);
            onOff = false;
            return;
        }
    }
}
