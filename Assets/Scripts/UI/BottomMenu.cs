using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class BottomMenu : MonoBehaviour
{
    public List<BottomItem> items;
    private int chosenItem = 0;
    private bool isInfoOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        Scroll(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scroll(int input)
    {
        if (input != 0)
        {
            isInfoOpened = false;
            items[chosenItem].transform.localScale = Vector3.one;
            items[chosenItem].CloseInfoBox();

            chosenItem = (chosenItem + input + items.Count) % items.Count;
            items[chosenItem].transform.localScale = Vector3.one*1.1f;
        }
        // Debug.Log("scroll by:" + input);
        
    }

    public void ToggleInfo()
    {
        isInfoOpened =! isInfoOpened;
        if (isInfoOpened)
        {
            items[chosenItem].OpenInfoBox();
        }
        else
        {
            items[chosenItem].CloseInfoBox();
        }
    }

    public GameObject GetChosenPrefab()
    {
        return items[chosenItem].prefab;
    } 
}
