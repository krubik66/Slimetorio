using System.Collections;
using System.Collections.Generic;
using TL.Core;
using UnityEngine;

public class Laboratory : MonoBehaviour
{
    public Context context;

    void FixedUpdate()
    {
        context.Leveling();
    }

}
