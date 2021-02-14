using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketPrefab_Demo : MonoBehaviour
{

    //SO! This is the actual Basket, AS seen in the structure of the game - It contains:
    //image of basket object
    //image of the fabric type
    //and a score object

    // IN CASE you are unfamilliar with PREFABS. Here is a  very simple explanation.
    // A prefab is a "pre-fabricated object" (or thats what i think it means)its just an object you can instantiate at will that was previously created
    // kinda like a template for an object. 

    // Prefabs appear BLUE in the hierarchy.
    // After creating an object you would like to turn into a prefab, just drag it from
    // your hierarchy into the project folder into an appropriate folder ("prefabs -> Blair's Prefabs" for example)

    //Now the problem with the prefab is that it'll have the same values all the time.
    //Thats why in the minigame manager we create a prefab then set its values in the next line. 
    
    //Sort of doing what a constructor would do with parameters. 
    //YOU CAN place prefabs in a scene then change its values in the inspector as well. 

    //What this object should do. Almost nothing. 

    //It will hold a collider, so that you can drop ur fabrics into, 
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
