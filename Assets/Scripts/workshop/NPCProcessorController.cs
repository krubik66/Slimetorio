using System.Collections;
using System.Collections.Generic;
using TL.Core;
using UnityEngine;

public class NPCProcessorController : NPCController
{
    public Workshop workshop;


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
            Inventory.AddResource(workshop.recipe.Item2, outputAmount);

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
