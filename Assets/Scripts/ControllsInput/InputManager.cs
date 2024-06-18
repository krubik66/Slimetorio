using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerControls playerInput;
    public PlayerControls.OnFootActions onFoot;
    private PlayerMotor motor;
    private PlayerLook look;
    private PlaceObjectController place;

    private MenuInput menu;
    // Start is called before the first frame update
    void Awake() {
        playerInput = new PlayerControls();
        onFoot = playerInput.OnFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        place = GetComponent<PlaceObjectController>();
        menu = GetComponent<MenuInput>();

        onFoot.Sprint.performed += ctx => motor.Sprint();
        onFoot.Rotate.performed += ctx => place.rotate(1);
        onFoot.ReverseRotate.performed += ctx => place.rotate(-1);
        onFoot.Click.performed += ctx => place.HandleClick();
        onFoot.RightClick.performed += ctx => place.HandleRightClick();
        onFoot.ToggleInfo.performed += ctx => place.HandleToggleInfo();
        onFoot.Pause.performed += ctx => menu.ToggleMenu();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>(),
                          onFoot.Flight.ReadValue<Vector2>());
    }

    private void OnEnable() {
        onFoot.Enable();
    }
    private void OnDisable() {
        onFoot.Disable();
    }
}
