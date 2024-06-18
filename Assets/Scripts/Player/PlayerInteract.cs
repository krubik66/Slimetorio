using System;
using System.Collections;
using System.Collections.Generic;
using TL.Core;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;

    private InputManager inputManager;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateUI(new Tuple<ResourceType, ResourceType>(ResourceType.food,ResourceType.food));
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, distance, mask)) {
            if(hit.collider.GetComponent<Marker>() != null) {
                Marker current = hit.collider.GetComponent<Marker>();
                if (current.enabled == true) {
                    playerUI.UpdateUI(current.NextResource());
                    if(inputManager.onFoot.Interact.triggered) {
                        current.ChangeToNext();
                    }
                }
            }
        }
    }
}
