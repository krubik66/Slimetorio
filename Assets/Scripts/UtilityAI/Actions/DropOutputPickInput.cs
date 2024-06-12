using System.Collections;
using System.Collections.Generic;
using TL.Core;
using UnityEngine;

namespace TL.UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "DropOutputPickInput", menuName = "UtilityAI/Actions/DropOutputPickInput")]
    public class DropOutputPickInput : Action
    {

        public override void Execute(NPCController npc)
        {
            Debug.Log("Dropped Off Output from process");
            foreach(var item in npc.Inventory.Inventory)
            {
                RequiredDestination.GetComponent<StorageInventory>().AddResource(item.Key, item.Value);
            }            
            npc.Inventory.RemoveAllResource();
            RequiredDestination.GetComponent<StorageInventory>().RemoveResource(requiredInput, 1);
            npc.Inventory.Inventory[requiredInput] = 1;
            npc.aiBrain.finishedExecutingBestAction = true;
        }

        public override void SetRequiredDestination(NPCController npc)
        {
            RequiredDestination = npc.context.GetClosestStorage();
            npc.mover.destination = RequiredDestination;
        }
    }
}
