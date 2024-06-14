using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TL.Core
{
    public enum ResourceType
    {
        food,
        stone,
        wood,
        plank,
        iron,
        crystal
    }

    public class ResourceTexturesAndModels
    {
        public static Dictionary<ResourceType, Texture> resourceUITextures = new Dictionary<ResourceType, Texture>
        {
            { ResourceType.wood, Resources.Load<Texture>("UI/wood") },
            { ResourceType.iron, Resources.Load<Texture>("UI/iron") },
            { ResourceType.plank, Resources.Load<Texture>("UI/plank") },
            { ResourceType.crystal, Resources.Load<Texture>("UI/crystal")},
            { ResourceType.stone, Resources.Load<Texture>("UI/stone")}
        };
    }
}