using System.Collections;
using System.Collections.Generic;
using TL.Core;
using UnityEngine;

public class NPCProcessorController : NPCController
{
    public Transform workshopPlace;
    public Workshop workshopScript;


    IEnumerator ProcessCoroutine(int time)
        {
            int counter = time;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }

            int amount = Inventory.Inventory[workshopScript.recipe.Item1];
            Inventory.RemoveResource(workshopScript.recipe.Item1, amount);
            workshopScript.GiveInput(amount);

            int outputAmount = workshopScript.GetOutput();
            Inventory.AddResource(workshopScript.recipe.Item2, outputAmount);

            // Decide our new best action after you finished this one
            //OnFinishedAction();
            aiBrain.finishedExecutingBestAction = true;
            yield break;
        }
    
    override public void DoWork(int time)
    {
        StartCoroutine(ProcessCoroutine(time));
    }
}
