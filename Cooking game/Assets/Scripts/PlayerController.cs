using UnityEngine;
using UnityEngine.VFX;

public class PlayerController : MonoBehaviour
{


    [SerializeField] private float walkSpeed = 7f;
    [SerializeField] private float turnSpeed = 25f;
    [SerializeField] private GameInput gameInput;
    private float playerHeight = 2.2f;
    private float playerWidth = .65f;
    private bool isWalking = false;

    private void Update()
    {
        Vector2 inputDirection = gameInput.GetMovementVectorNormalized();
        Vector3 movingDirection = new Vector3(inputDirection.x, 0, inputDirection.y);
        Vector3 amountToAdd = movingDirection  * walkSpeed * Time.deltaTime;
        isWalking = inputDirection != new Vector2(0, 0);
        if (isWalking && CanMove(movingDirection,amountToAdd))
        {
            transform.position += amountToAdd;
        }
        else
        {
            Vector3 newMovingDirection = new Vector3(inputDirection.x, 0, 0).normalized;
            amountToAdd = newMovingDirection * walkSpeed * Time.deltaTime;
            if (CanMove(newMovingDirection, amountToAdd))
            {
                transform.position += amountToAdd;
            }
            else
            {
                newMovingDirection = new Vector3(0, 0, inputDirection.y).normalized;
                amountToAdd = newMovingDirection * walkSpeed * Time.deltaTime;
                if (CanMove(newMovingDirection, amountToAdd))
                {
                    transform.position += amountToAdd;
                }
            }
        }
       

         transform.forward = Vector3.Slerp(transform.forward, movingDirection, Time.deltaTime * turnSpeed);

    }
    private bool CanMove(Vector3 direction,Vector3 positionToAdd)
    {
        RaycastHit hit;
        bool canMove = !Physics.CapsuleCast(transform.position,transform.position + new Vector3(0,playerHeight,0), playerWidth,direction, out hit, positionToAdd.magnitude);
       
        return canMove;
    }
    public bool IsWalking()
    {
        return isWalking;
    }

}
