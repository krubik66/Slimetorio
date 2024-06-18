using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using TL.Core;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promptText;
    [SerializeField]
    private TextMeshProUGUI keyHint;
    
    [SerializeField]
    private RawImage image1;
    [SerializeField]
    private RawImage image2;

    public void UpdateUI(Tuple<ResourceType,ResourceType> types) {
        if (types.Item1 == ResourceType.food)
        {
            promptText.text = "";
            keyHint.text = "";
            image1.color = new Color { a = 0 };
            image2.color = new Color { a = 0 };
            return;
        }
        promptText.text = " => ";
        keyHint.text = "[F]:";
        image1.color = new Color { a = 1, r = 255, b = 255, g = 255 };
        image1.texture = ResourceTexturesAndModels.resourceUITextures[types.Item2];
        image2.color = new Color { a = 1, r = 255, b = 255, g = 255 };
        image2.texture = ResourceTexturesAndModels.resourceUITextures[types.Item1];
    }
}
