using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a Sample of how we would use the fabric system
/// in game.
/// 
/// The reason we use this system is to engage the designers and
/// producers in the production process, while freeing up coding time.
/// 
/// When a new fabric is created and added to the master table, our implementation
/// will automatically be able to account for any new fabrics. 
/// 
/// Summary of steps:
/// 
/// -Artists create asset material and ui asset
/// 
/// -Designers create new 'Fabric' object, and add it to the master table
/// 
/// -Programmers Create a Fabric List<ScriptableFabric> in the player with desired logic
///       - This is done by looping through the master table and adding fabrics to 
///       the player table, if the player meets the level requirement for that fabric.
///       
/// -Programmers See Below for basic implementations.
///         -See SampleScene
///         -See FabricScriptableObject Script for enums or just play with code autofill.               
///                                         -ie. ScriptableFabric myFabric
///                                              myFabric.look through here<-
/// 
/// -In General You can code how you like, but I would prefer some of the example structure below. 
/// 
/// -Keep things clean, make scripts that are as single purposed as possible. 
/// 
/// -Your scripts *should* be short concise and to the point, and should be simple and readable enough
///  as to not need comments.
///  
/// </summary>
public class ReadmeFabricImplementation : MonoBehaviour
{         
    //Seperate Types, And keep Types together. 
    public FabricMasterTable _FabricMasterTable;
    
    private List<ScriptableFabric> samplePlayerFabricList;
    
    [HideInInspector] 
    public int samplePlayerLevel;
    
    public GameObject SampleUIobject, sampleGameController;
    
    private FabricSeason thisSeason;

    enum States {Idle, ClickingFabric, MovingFabrics, LevelingUp, ClosingScene  }
    States State = States.Idle;
    
    void Start() //Keep Start and Update pretty clean. Use Functions. 
    {
        samplePlayerLevel = 4;
        CheckFabricList();  
    }
    
    void Update() //A simple State machine we can have as a standard for active objects. 
    {
        switch (State)
        {
            case States.Idle:
                break;
            case States.MovingFabrics:
                break;
            case States.LevelingUp://States should contain functions not logic. Keep this clean as possible. 
                                   //Of course you might need an if statement or whatever but ya..
                CheckFabricList();
                break;
            case States.ClosingScene:
                break;
            default:
                break;
        }
    }

    void CheckFabricList() //Functions should be single purposed. 
    {
        for (int i = 0; i < _FabricMasterTable.Fabrics.Length; i++)
        {
            if (samplePlayerLevel >= _FabricMasterTable.Fabrics[i].PlayerLevelRequirement)
            {
                AddFabricToPlayer(_FabricMasterTable.Fabrics[i]); //notice that adding and checking are different purposes
            }
        }

    }

    //When Possible Use 1 Line of code instead of the above format. As seen below. 
    void AddFabricToPlayer(ScriptableFabric Fabric) { samplePlayerFabricList.Add(Fabric); }

    //Be Descriptive with parameters.
    void CompareSeason(FabricSeason FabricSeasons, FabricSeason DesiredSeason)
    {
        if(thisSeason == FabricSeason.Fall) { /*Do Stuff*/}
    }

    void CompareFabricMaterials(ScriptableFabric Fabric, FabricMaterials DesiredMaterial)
    {
        for (int i = 0; i < Fabric.FabricComposition.Length; i++)
        {
            if(Fabric.FabricComposition[i] == DesiredMaterial) { /* Do Stuff */}
            if(Fabric.FabricComposition[i] == FabricMaterials.Nylon) { /* Do Stuff */ }
        }
    }
}
