using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlaceObjectController : MonoBehaviour
{
    private Camera _cam;

    [SerializeField]
    private LayerMask Mask;

    public GameObject PlaceableObjectPrefab;

    private GameObject PlaceableObject;

    public float placeRange = 30f;

    private float _rotation = 0;

    public BottomMenu bottomMenu;

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
        moveObject();
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

    public void changeObject(GameObject gameObjectPrefab)
    {
        PlaceableObjectPrefab = gameObjectPrefab;
        if (PlaceableObject != null)
        {
            Destroy(PlaceableObject);
        }
        PlaceableObject = Instantiate(gameObjectPrefab);
    }

    public void rotate(float input)
    {
        _rotation += input;
    }

    public void startPlacing()
    {
        
    }

}
