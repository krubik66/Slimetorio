using System;
using System.Collections;
using System.Collections.Generic;
using TL.Core;
using UnityEngine;

public class Marker : MonoBehaviour
{
    // Start is called before the first frame update
    Context context;
    private Dictionary<ResourceType, ResourceType> basicResources = new Dictionary<ResourceType, ResourceType>{
        {ResourceType.stone,ResourceType.wood},
        {ResourceType.wood,ResourceType.iron},
        {ResourceType.iron,ResourceType.crystal},
        {ResourceType.crystal,ResourceType.stone}
    };
    public ResourceType resourceToHarvest;
    void Awake()
    {
        context = FindObjectOfType<Context>();
    }

    void Start()
    {
        // context.addDestination(DestinationType.marker, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Tuple<ResourceType,ResourceType> NextResource()
    {
        return new Tuple<ResourceType, ResourceType>(basicResources[resourceToHarvest],resourceToHarvest);
    }

    public void ChangeToNext()
    {
        resourceToHarvest = basicResources[resourceToHarvest];
    }
}
