using System.Collections;
using System.Collections.Generic;
using TL.Core;
using TL.UtilityAI;
using UnityEngine;


public class NPCProcessorController : NPCController
{
    public Workshop workshop;

    void Start()
        {
            mover = GetComponent<MoveController>();
            aiBrain = GetComponent<AIBrain>();
            Inventory = GetComponent<NPCInventory>();
            stats = GetComponent<Stats>();
            context = GameObject.FindWithTag("context").GetComponent<Context>();

            float distance = Mathf.Infinity;
            Transform nearestMarker = null;
            if (context )
            {
                List<Transform> markers = context.Destinations[DestinationType.marker];
                foreach (Transform marker in markers)
                {
                    float distanceFromMarker = Vector3.Distance(marker.position, transform.position);
                    if (distanceFromMarker < distance)
                    {
                        nearestMarker = marker;
                        distance = distanceFromMarker;
                    }
                }
                currentState = State.decide;
                marker = nearestMarker.GetComponent<Marker>();
            }
        }


    IEnumerator ProcessCoroutine(int time)
        {
            int counter = time;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }

            int amount = Inventory.Inventory[workshop.recipe.Item1];
            Inventory.RemoveResource(workshop.recipe.Item1, amount);
            workshop.GiveInput(amount);

            int outputAmount = workshop.GetOutput();
            // Debug.Log("Picked: " + outputAmount + " " + workshop.recipe.Item2);
            Inventory.AddResource(workshop.recipe.Item2, outputAmount);
            // Debug.Log(Inventory.Inventory[workshop.recipe.Item2]);

            // Decide our new best action after you finished this one
            //OnFinishedAction();
            aiBrain.finishedExecutingBestAction = true;
            yield break;
        }
    
    override public void DoWork(int time)
    {
        // Debug.Log(":::::");
        StartCoroutine(ProcessCoroutine(time));
    }
}
