using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TL.Core;
using UnityEngine;

public class BottomItem : MonoBehaviour
{
    public GameObject prefab;

    public InfoBox infoBox;

    public List<ResourceType> types;
    public List<int> amounts;

    public void OpenInfoBox()
    {
        infoBox.gameObject.SetActive(true);
        infoBox.setCosts(types.Zip(amounts, (k, v) => new { k, v })
                            .ToDictionary(x => x.k, x => x.v));
    }

    public void CloseInfoBox()
    {
        infoBox.gameObject.SetActive(false);
    }
}
