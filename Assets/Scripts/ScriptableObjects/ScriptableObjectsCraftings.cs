using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Crafting", menuName = "ScriptableObjects/Crafting")]
public class ScriptableObjectsCraftings : ScriptableObject
{
    public Dictionary<ScriptableObjectsItem, int> input;

    public float processTime;

    public ScriptableObjectsItem output;
    
}
