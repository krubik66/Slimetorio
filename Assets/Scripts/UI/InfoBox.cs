using System.Collections;
using System.Collections.Generic;
using TL.Core;
using UnityEngine;

public class InfoBox : MonoBehaviour
{
    public List<ItemCount> costs;

    public void setCosts(Dictionary<ResourceType, int> Costs)
    {
        // int n = 0;
        // foreach (var cost in Costs)
        // {
        //     costs[n].enabled = true;
        //     costs[n].Amount = cost.Value;
        //     costs[n].Type = cost.Key;
        //     n += 1;
        // }
        // for (int i = n; i < costs.Count; i++)
        // {
        //     costs[i].enabled = false;
        // }
    }

    void OnEnable()
    {
        setCosts(new Dictionary<ResourceType, int>());
    }
}
