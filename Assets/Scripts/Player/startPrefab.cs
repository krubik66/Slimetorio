using System.Collections;
using System.Collections.Generic;
using TL.Core;
using UnityEngine;

public class startPrefab : MonoBehaviour
{
    public NPCController childNPC;

    public GameObject worker;

    public Marker marker;
    public void PrefabOn()
    {
        if (childNPC != null)
        {
            childNPC.enabled = true;
        }
        if (worker != null)
        {
            worker.SetActive(true);
        }
        if (marker != null)
        {
            marker.enabled = true;
        }
    }
}
