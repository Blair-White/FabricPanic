using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RushRequestController : MonoBehaviour
{
    private float currentTime = 0.0f;
    private float maxTime = 30.0f;
    [SerializeField]
    private TextMeshProUGUI timerText;
    public enum States //These are our Game States. enums are very useful as you will see in the update function. 
    {
        EnterInit,     //Initializes: object is spawned by outside source. Give commands to relevant objects.
        InitComplete,  //Initialization Complete: Completed any initialization of objects. This state may remain empty, we will see. 
        EnterGameplay, //Enter Gameplay: Spawn all fabrics, baskets etc, make sure the game is all setup.
        Gameplay,      //Game Begins: Start the timer, hand control over to the player.
        FabricDroppedCorrect, //If this state hits, we can Add Score, Feedback the user and loop back to gameplay.
        FabricDroppedIncorrect, //Same ish as above
        EnterVictory,     //This state is if the player has placed all the fabric before time has run out.
        Victory,       //Complete any necessary tasks
        EnterTimedOut, //This state is if the timer has run out.
        Timedout,      //Complete State
        EnterEndGame,  //The game has finished, boot up any needed objects. Visuals, text etc.
        EndGame,       //Call the last function to close the game. 
        PauseGame      //Reserved in case we need it. 
        //Why do we use "Enter" states? so we can one shot commands and then move right into the "running state" 
        //Think of Enter as states as EVENTS you probably wanna run once to set values then move into the actual state.
        //Below should explain further.
    }

    public States State; //You can always check this state from other objects, We could use a singleton pattern (Much Better)
    //but lets not do that as it might get confusing and a little much for now. 
    //Example: after setting a GameObject Variable to THIS gameobject ("GameManager")
    // if(GameManager.State == GameManager.GetComponent<MiniGameManager>().States.GamePlay {Do Stuff}

    public GameObject GamePanel, TitlePanel, TitleText, SubtitlePanel, SubtitleText; // Our main objects. 
    public GameObject BasketPrefab, FabricPrefab; // The Prefabricated Basket type 
    public GameObject[] Baskets; //The array of baskets, I will show you below what to do with this in Start(); 
    public TextMeshProUGUI EndText;
    //*Dont forget to set the size of this array to 4 in the inspector****
    private bool initComplete;
    private float imageAlpha;
    private void Start()
    {
        currentTime = maxTime;
        //Create our baskets.
        //for (int i = 0; i < 4; i++)
        //{
        //    GameObject basket = Instantiate(BasketPrefab);
        //    //you can set the placement of each individually using i
        //    //example basket.transform.position = new vector3(i * 2 + this.transform.position etc. 
        //    //Set any relevant data here:
        //    //basket.fabricType = 0 
        //    //then you can use that fabric type to set the image of the fabric label etc. 
        //    //basket.uberness = "alot"
        //    Baskets[i] = basket;
        //}

    }

    private void Update()
    {

        //Trick to do this quickly:
        //Type "switch" press tab twice, type State to change ("Switch_on") press arrow key anywhere = magic. creates the state machine for you.

        //This is the basic State Machine, Some teachers don't like seeing this, but that is because they never actually make video games. 

        switch (State)
        {
            case States.EnterInit:
                InitializeGame();//check below for an example of what u might do in this function. 
                if (initComplete) State = States.InitComplete; //See how it works? p-cool. 
                break;
            case States.InitComplete:
                //Do Stuff, set stuff and move on.
                State = States.EnterGameplay;
                break;
            case States.EnterGameplay:
                EnterGameplay();
                //Boot up our Gameplay Stuff
                //If Gameplay is setup
                State = States.Gameplay;
                break;
            case States.Gameplay:
                RunGame();

                //If Fabric was dropped Correctly?
                //State = States.FabricDroppedCorrect;
                //  else if fabric dropped incorrectly
                //State = States.FabricDroppedIncorrect;
                // else if timer ran out?
                //State = States.EnterTimedOut;
                // else if all fabrics placed?
                //if(dragController.totalFabrics == 0)
                //State = States.EnterVictory;

                break;
            case States.FabricDroppedCorrect:
                //Addscore Give Feedback etc.
                //Then loop back to enter gameplay. this will double check if gameplay is ok to go.
                State = States.EnterGameplay;
                //then it will flow into gameplay again.
                break;
            case States.FabricDroppedIncorrect:
                //Same as above but u do diff sutff.
                break;
            case States.EnterVictory:     // WIN CONDITION HERE 
                GamePanel.SetActive(false);
                EndText.color = Color.green;
                EndText.text = "YOU WON";
                State = States.EndGame;
                //I think thats enough you get the picture
                //PLEASE talk to me if you don't understand or want help, or think you  know a better way
                //or think im an idiot, or just anything. I'm happy to do whatevers. 
                break;
            case States.Victory:
                break;
            case States.EnterTimedOut:
                State = States.Timedout;
                break;
            case States.Timedout:          // LOSE CONDITION HERE
                GamePanel.SetActive(false);
                EndText.color = Color.red;
                EndText.text = "YOU LOST";
                State = States.EndGame;
                break;
            case States.EnterEndGame:
                break;
            case States.EndGame: // end minigame
                break;
            case States.PauseGame:
                break;
            default:
                break;
        }

    }

    void RunGame()
    {
        currentTime -= 1 * Time.deltaTime;
        timerText.text = currentTime.ToString("0");
        if (currentTime <= 0)
        {
            currentTime = 0;
            State = States.EnterTimedOut;
        }
        if (currentTime <= 5)
        {
            timerText.color = Color.red;
        }

        if(Baskets[0].GetComponent<FabricDrop>().isCompleted == true &&
           Baskets[1].GetComponent<FabricDrop>().isCompleted == true &&
           Baskets[2].GetComponent<FabricDrop>().isCompleted == true &&
           Baskets[3].GetComponent<FabricDrop>().isCompleted == true)
        {
            State = States.EnterVictory;
        }
    }

    void EnterGameplay()
    {

    }
    void EndGame()
    {
        
    }

    void InitializeGame()
    {
        //imageAlpha += 0.001f;
        ////set all fading in objects alpha
        ////example
        //Baskets[0].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, imageAlpha);//this will fade them up to 1.0f
        //BackingPanel.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, imageAlpha);
        //if (imageAlpha >= 1)
        //{
        //    initComplete = true;
        //    imageAlpha = 0; //remember to reset values as much as possible. 
        //}
        
        initComplete = true;
    }
}
