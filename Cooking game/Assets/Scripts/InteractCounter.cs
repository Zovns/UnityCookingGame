using System;
using UnityEngine;

public class InteractCounter : MonoBehaviour
{
    [SerializeField] GameInput gameInput;
    
    private float interactDistance = 2f;
    private GameObject activeCounter;

    // Update is called once per frame

    private void Start()
    {
        gameInput.OnInteractAction += Interact;
    }

    void Update()
    {
       Vector2 inputDirection =  gameInput.GetMovementVectorNormalized();
       Vector3 movingDirection = new Vector3(inputDirection.x, 0, inputDirection.y);
        if (inputDirection == new Vector2(0, 0))
        {
            return;
        }
            

        if (Physics.Raycast(transform.position, movingDirection, out RaycastHit hit,interactDistance)){
            if (hit.transform.GetComponentInParent<ClearCounter>())
            {
                if(activeCounter != null) {
                    activeCounter.GetComponent<CounterVisualSelected>().SetSelected(false);
                }
                activeCounter = hit.transform.gameObject;
                activeCounter.GetComponent<CounterVisualSelected>().SetSelected(true);
            }
            else
            {
                if (activeCounter != null)
                {
                    activeCounter.GetComponent<CounterVisualSelected>().SetSelected(false);
                }
                activeCounter = null;
            }
        }
        else
        {
            if (activeCounter != null)
            {
                activeCounter.GetComponent<CounterVisualSelected>().SetSelected(false);
            }
            activeCounter = null;
        }

    }

    public GameObject GetActiveCounter()
    {
        return activeCounter;
    }

    public void Interact(object sender, EventArgs e)
    {
        if (activeCounter)
        {
            activeCounter.GetComponent<ClearCounter>().Interact();
        }
    }
}
