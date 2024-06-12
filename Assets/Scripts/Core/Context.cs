using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TL.Core
{
    public class Context : MonoBehaviour
    {   
        public Storage startingStorage;
        public GameObject home;
        public string resourceTag = "resource";
        public float MinDistance = 5f;
        public TopMenu storageUI;
        public Dictionary<DestinationType, List<Transform>> Destinations { get; private set; }

        private void Start()
        {
            List<Transform> restDestinations = new List<Transform>() { home.transform };
            List<Transform> storageDestinations = new List<Transform>() { startingStorage.transform };
            List<Transform> resourceDestinations = GetAllResources();

            Destinations = new Dictionary<DestinationType, List<Transform>>()
            {
                { DestinationType.rest, restDestinations},
                { DestinationType.storage, storageDestinations },
                { DestinationType.resource, resourceDestinations }
            };
        }

        private List<Transform> GetAllResources()
        {
            Transform[] gameObjects = FindObjectsOfType<Transform>();
            List<Transform> resources = new List<Transform>();
            foreach (Transform go in gameObjects)
            {
                if(go.gameObject.tag == resourceTag)
                {
                    resources.Add(go);
                }
            }
            return resources;
        }

        public void addDestination(DestinationType type, Transform transform)
        {
            if (Destinations[type] != null)
            {
                Destinations[type].Add(transform);
            }
            else
            {
                Destinations[type] = new List<Transform> {transform};
            }
        }

        private void Update()
        {
            UpdateUI();
            Destinations[DestinationType.resource] = GetAllResources();
        }

        void UpdateUI()
        {
            var storageSum = new Dictionary<ResourceType, int>();

            foreach(Transform storageTransform in Destinations[DestinationType.storage])
            {
                Storage storage = storageTransform.GetComponent<Storage>();
                foreach(var item in storage.Inventory)
                {
                    if (storageSum.ContainsKey(item.Key))
                    {
                        storageSum[item.Key] += item.Value;
                        Debug.Log(storageSum[item.Key]);
                        Debug.Log(item.Key);
                    }
                    else 
                    {
                        storageSum[item.Key] = item.Value;
                        Debug.Log(storageSum[item.Key]);
                        Debug.Log(item.Key);
                    }
                    
                }
            }
            
            storageUI.setValues(storageSum);
        }

        public Transform GetClosestStorage()
        {
            return Destinations[DestinationType.storage][0].transform;
        }

    }
}
