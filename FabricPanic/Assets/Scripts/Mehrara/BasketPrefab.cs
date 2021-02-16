using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketPrefab : MonoBehaviour
{
    //use a collision event below along with simillar logic to our dragndrop function. 

    //It will set its fabric image to the appropriate image. which we set upon creation by setting a value. int easiest way.
    //(Later this might have to be changed to incorporate my fabric creation system but just use integer for now)

    //It will send messages to the manager. Example in start.

    GameObject gameManager;
    void Start()
    {   //the object to send to| The FunctionName     | Parameter | If using an integer u might have to specify this last part
        gameManager.SendMessage("FabricPlacedCorrectly", 1, SendMessageOptions.RequireReceiver);
        //gameManager.SendMessage("FabricPlacedCorrectly", 0); //this will return an error because it thinks the 0 is the 
        //sendmessageoptions part - and youre not actually passing a parameter.
    }

    // Update is called once per frame
    void Update()
    {

    }
}
