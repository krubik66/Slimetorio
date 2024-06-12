using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class BottomMenu : MonoBehaviour
{
    public Image frame;
    public List<BottomItem> items;
    private int chosenItem = 0;
    public bool canScroll = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scroll(int input)
    {
        if (canScroll)
        {
            chosenItem = (chosenItem + input/120) % items.Count;
        }
    }

    public GameObject GetChosenPrefab()
    {
        return items[chosenItem].prefab;
    } 
}
