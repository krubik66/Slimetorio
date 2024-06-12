using System.Collections;
using System.Collections.Generic;
using TL.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    public ResourceType type;

    public string Text 
    {
        set
        {
            text.text = value;
        }
        get
        {
            return text.text;
        }
    }
}
