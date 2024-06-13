using System.Collections;
using System.Collections.Generic;
using TL.Core;
using UnityEngine;

namespace TL.UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "FactoryMustRunConsideration", menuName = "UtilityAI/Considerations/Factory Must Run")]
    public class FactoryMustRunConsideration : Consideration
    {
        [SerializeField] private ResourceType neededResource;

        public override float ScoreConsideration(NPCController npc)
        {   
            var inv = npc.Inventory.Inventory;
            return (inv.ContainsKey(neededResource) && inv[neededResource] > 0) ? 0 : 1;
        }
    }
}
