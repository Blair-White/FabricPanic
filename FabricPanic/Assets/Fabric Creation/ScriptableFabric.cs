using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


    public enum FabricColor1 { Red, Orange, Yellow, Green, Blue, Pink, Purple, Neutral, Multicolor}
    public enum FabricColor2 { Red, Orange, Yellow, Green, Blue, Pink, Purple, Neutral, Multicolor}
    public enum FabricPattern { Plain, Striped, PolkaDot, Plaid, Geometric, Floral, Graphic }
    
    public enum FabricTrait { Bright, Dark, Warm, Cool, Child, Feminine, Masculine, Sporty }
    public enum FabricHolliday { Lunar, CherrBlossom, Christmas, Halloween}
    public enum FabricSeason { AllSeason, Winter, Spring, Summer, Fall }

[CreateAssetMenu(fileName = "Fabric", menuName = "FabricCreator/Fabric", order = 1)]
public class ScriptableFabric : ScriptableObject
{    
    [SerializeField] public string FabricName; 
    [SerializeField] public FabricColor1 FabricColor1;
    [SerializeField] public FabricColor2 FabricColor2;
    [SerializeField] public FabricPattern FabricPattern;
    [SerializeField] public FabricTrait FabricTraits;
    [SerializeField] public FabricHolliday FabricHolliday;
    [SerializeField] public FabricSeason _FabricSeason;
    [SerializeField] public Material AssetMaterial;
    [SerializeField] public Sprite UiAsset;   
}