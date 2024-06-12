using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class BottomMenu : MonoBehaviour
{
    public List<BottomItem> items;
    private int chosenItem = 0;

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
        // Debug.Log("scroll by:" + input);
        items[chosenItem].transform.localScale = Vector3.one;
        chosenItem = (chosenItem + input + (items.Count * 10)) % items.Count;
        items[chosenItem].transform.localScale = Vector3.one*1.1f;
    }

    public GameObject GetChosenPrefab()
    {
        return items[chosenItem].prefab;
    } 
}
