using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TL.UtilityAI;
using TL.Core;

namespace TL.UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "Process", menuName = "UtilityAI/Actions/Process")]
    public class Process : Action
    {
        public override void Execute(NPCController npc)
        {
            npc.DoWork(3);
        }

        public override void SetRequiredDestination(NPCController npc)
        {
            NPCProcessorController imAProcessor = (NPCProcessorController) npc;
            RequiredDestination = imAProcessor.workshop.transform;
            npc.mover.destination = RequiredDestination;
        }
    }
}
