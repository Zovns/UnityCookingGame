using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private PlayerInput playerInput;
    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.PlayerInputAction.Enable();
    }
    public Vector2 GetMovementVectorNormalized()
    {

        Vector2 inputDirection = playerInput.PlayerInputAction.Move.ReadValue<Vector2>();
       
        inputDirection.Normalize();
        return inputDirection;
    }
}
