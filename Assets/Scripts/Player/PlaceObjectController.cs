using System.Collections;
using System.Collections.Generic;
using TL.Core;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlaceObjectController : MonoBehaviour
{
    private Camera _cam;

    [SerializeField]
    private LayerMask Mask;
    private GameObject PlaceableObject;

    public float placeRange = 30f;

    private float _rotation = 0;

    public BottomMenu bottomMenu;
    
    public Context context;

    private bool _placeMode = false;

    private void Awake()
    {
        _cam = GetComponent<PlayerLook>().cam;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_placeMode)
        {
            if (PlaceableObject == null)
            {
                changeObject(bottomMenu.GetChosenPrefab());
            }
            moveObject();
        }
    }

    void moveObject()
    {
        if (PlaceableObject != null)
        {
            Ray ray = new(_cam.transform.position, _cam.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, placeRange, Mask))
            {
                PlaceableObject.transform.position = raycastHit.point;
            }
        }
    }

    private void changeObject(GameObject gameObjectPrefab)
    {
        if (PlaceableObject != null)
        {
            Destroy(PlaceableObject);
        }
        PlaceableObject = Instantiate(gameObjectPrefab);
    }

    public void rotate(int input)
    {
        if (input != 0)
        {
            if (_placeMode)
            {
                _rotation += input*30;
            }
            else
            {                
                bottomMenu.Scroll(input);
            }
        }
    }

    public void HandleClick()
    {
        if (!_placeMode)
        {
            _placeMode = true;
        }
        else
        {
            Place();
        }
    }

    public void HandleRightClick()
    {
        if (_placeMode)
        {
            _placeMode = false;
            Destroy(PlaceableObject);
        }
    }

    private void Place()
    {
        PlaceableObject = null;
    }

}
