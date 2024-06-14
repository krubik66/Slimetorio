using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TL.UtilityAI;
using TL.Core;
using Unity.VisualScripting;

namespace TL.UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "Work", menuName = "UtilityAI/Actions/Work")]
    public class Work : Action
    {
        public override void Execute(NPCController npc)
        {
            npc.DoWork(3);
            var resource = RequiredDestination.GetComponent<Resource>();
            if (resource != null)
            {
                npc.Inventory.AddResource(resource.ResourceType, 1);
                // Debug.Log("can collect this shit!!!" + npc.Inventory.Inventory[resource.ResourceType]);
            }
        }

        public override void SetRequiredDestination(NPCController npc)
        {
            float distance = Mathf.Infinity;
            Transform nearestMarker = npc.marker.GetComponent<Transform>();
            Transform nearestResource = null;

            List<Transform> resources = npc.context.Destinations[DestinationType.resource];
            foreach (Transform resource in resources)
            {
                float distanceFromResource = Vector3.Distance(resource.position, nearestMarker.position);
                if (resource.GetComponent<Resource>().ResourceType == npc.marker.resourceToHarvest && distanceFromResource < distance)
                {
                    nearestResource = resource;
                    distance = distanceFromResource;
                }
            }

            RequiredDestination = nearestResource;
            npc.mover.destination = RequiredDestination;
        }
    }
}
