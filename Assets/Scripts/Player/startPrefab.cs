using System.Collections;
using System.Collections.Generic;
using TL.Core;
using UnityEngine;
using UnityEngine.AI;

public class startPrefab : MonoBehaviour
{
    public NPCController childNPC;

    public GameObject worker;

    public Marker marker;

    public Laboratory laboratory;
    public void PrefabOn()
    {
        var context = FindObjectOfType<Context>();

        if (childNPC != null)
        {
            childNPC.enabled = true;
            childNPC.GetComponent<NavMeshAgent>().speed *= context.workerSpeedLevel;
        }
        if (worker != null)
        {
            worker.SetActive(true);
            worker.GetComponentInChildren<NavMeshAgent>().speed *= context.workerSpeedLevel;
        }
        if (marker != null)
        {
            marker.enabled = true;
            context.addDestination(DestinationType.marker, marker.transform);
        }
        if (laboratory != null)
        {
            laboratory.enabled = true;
            laboratory.context = context;
        }
    }
}
