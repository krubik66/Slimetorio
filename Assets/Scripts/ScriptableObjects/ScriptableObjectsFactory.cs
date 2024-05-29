using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Factory", menuName = "ScriptableObjects/Factory")]
public class ScriptableObjectsFactory : ScriptableObject
{
    public List<ScriptableObjectsCraftings> availableCraftings;

    public bool needsFuel;
}
