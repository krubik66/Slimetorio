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
    // Start is called before the first frame update
    void Awake() {
        playerInput = new PlayerControls();
        motor = GetComponent<PlayerMotor>();
        onFoot = playerInput.OnFoot;
        look = GetComponent<PlayerLook>();
        onFoot.Sprint.performed += ctx => motor.Sprint();
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
