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
        plank
    }

    public class ResourceTexturesAndModels
    {
        public static Dictionary<ResourceType, Texture> resourceUITextures = new Dictionary<ResourceType, Texture>
        {
            { ResourceType.wood, Resources.Load<Texture>("UI/wood") },
            { ResourceType.stone, Resources.Load<Texture>("Textures/StoneTexture") },
            { ResourceType.plank, Resources.Load<Texture>("Textures/IronTexture") },
        };
    }
}