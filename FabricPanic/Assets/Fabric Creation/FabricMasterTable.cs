using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FabricMasterTable", menuName = "FabricCreator/FabricMasterList", order = 2)]
public class FabricMasterTable : ScriptableObject
{
    [SerializeField]
    public ScriptableFabric[] Fabrics;
}
