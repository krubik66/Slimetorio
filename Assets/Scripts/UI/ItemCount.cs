using System.Collections;
using System.Collections.Generic;
using TL.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCount : MonoBehaviour
{
    public ResourceType Type
    {
        set
        {
            _resourceType = value;
            if (image != null)
            {
                image.texture = ResourceTexturesAndModels.resourceUITextures[value];
            }            
        }
        get
        {
            return _resourceType;
        }
    }

    private ResourceType _resourceType;
    public int Amount
    {
        set
        {
            _amount = value;
            if (text != null)
            {
                text.text = value.ToString();
            }
        }
        get
        {
            return _amount;
        }
    }

    private int _amount;

    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private RawImage image;
}
