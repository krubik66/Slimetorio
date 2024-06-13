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
        // Debug.Log(stats.Count);
        foreach(var text in stats)
        {
            // Debug.Log("::");
            if(values.TryGetValue(text.type, out int value))
            {
                // Debug.Log("::" + value);
                text.Text = value.ToString();
            }
        }
    }

}
