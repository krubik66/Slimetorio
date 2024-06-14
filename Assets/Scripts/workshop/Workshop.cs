using System;
using System.Collections;
using System.Collections.Generic;
using TL.Core;
using UnityEngine;

public class Workshop : MonoBehaviour
{
    public ResourceType resTypeInput = ResourceType.wood;
    public ResourceType resTypeOutput = ResourceType.plank;
    public Tuple<ResourceType, ResourceType> recipe = Tuple.Create(ResourceType.wood, ResourceType.plank);
    public int inputAmount = 0;
    public int outputAmount = 0;

    private int maxcapacity = 50;
    public int processingTime = 5;
    Context context;

    void Awake()
    {
        context = GameObject.FindObjectOfType<Context>();
    }

    // void Start() {
    //     StartCoroutine(Processing());
    // } 

    // IEnumerator Processing()
    //     {
    //         float counter = processingTime / context.processingSpeed - 1;
    //         Debug.Log("Counter until process of workshop: " + counter);
    //         while (counter > 0)
    //         {
    //             yield return new WaitForSeconds(counter);
    //             counter = 0;
    //         }
    //         if(inputAmount > 0) {
    //             inputAmount--;
    //             outputAmount++;
    //             Debug.Log("Processed one time. Current output: " + outputAmount);
    //         }

    //         yield return new WaitForSeconds(1);
    //     }

    public int GetOutput() {
        int difference = inputAmount;
        inputAmount = 0;
        return difference;
    }

    public void GiveInput(int howMuch) {
        inputAmount += howMuch;
        if (inputAmount > maxcapacity) {
            inputAmount = maxcapacity;
        }
    }
}
