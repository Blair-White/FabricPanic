using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


    public enum FabricMaterials { Cotton, Wool, Nylon, Cashmere}
    public enum FabricAttribute { Sporty, Festive, Alluring }
    public enum FabricSeason { AllSeason, Winter, Spring, Summer, Fall }

[CreateAssetMenu(fileName = "Fabric", menuName = "FabricCreator/Fabric", order = 1)]
public class ScriptableFabric : ScriptableObject
{    
    [SerializeField] public string FabricName; 
    [SerializeField] public int PlayerLevelRequirement;
    [SerializeField] public FabricMaterials[] FabricComposition;
    [SerializeField] public FabricAttribute[] _FabricAttributes;
    [SerializeField] public FabricSeason[] _FabricSeason;
    [SerializeField] public Material AssetMaterial;
    [SerializeField] public Sprite UiAsset;   
}