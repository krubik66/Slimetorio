using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]
public class ScriptableObjectsItem : ScriptableObject
{
    public ScriptableObjectsItemType scriptableObjectsItemType;

    public string ItemName;

    public Sprite sprite;

    public GameObject item3d;
}
