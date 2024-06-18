using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuInput : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas1;
    [SerializeField]
    private Canvas canvas2;

    private bool isOpened = false;

    
    public void ToggleMenu() {
        
        isOpened =! isOpened;

        if(isOpened) {
            canvas1.gameObject.SetActive(false);
            canvas2.gameObject.SetActive(true);
            Cursor.visible = true;
        }
        else {
            canvas2.gameObject.SetActive(false);
            canvas1.gameObject.SetActive(true);
            Cursor.visible = false;
        }
    }
}
