using System.Collections;
using System.Collections.Generic;
using TL.Core;
using TMPro;
using UnityEngine;

public class TopMenu : MonoBehaviour
{
    public List<Stat> stats = new();
    
    public void setValues(Dictionary<ResourceType, int> values)
    {
        foreach(var text in stats)
        {
            if(values.TryGetValue(text.type, out int value))
            {
                text.Text = value.ToString();
            }
        }
    }
}
