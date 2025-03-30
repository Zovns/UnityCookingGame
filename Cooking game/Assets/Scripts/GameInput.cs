using System;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public EventHandler OnInteractAction;
    private PlayerInput playerInput;
    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.PlayerInputAction.Enable();
    }
    private void Start()
    {
        playerInput.PlayerInputAction.Interact.started += PerformedInteract;
    }
    private void PerformedInteract(InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }
    public Vector2 GetMovementVectorNormalized()
    {

        Vector2 inputDirection = playerInput.PlayerInputAction.Move.ReadValue<Vector2>();
       
        inputDirection.Normalize();
        return inputDirection;
    }
}
