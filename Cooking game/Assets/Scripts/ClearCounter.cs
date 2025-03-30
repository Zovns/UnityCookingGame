using UnityEditor;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] InteractCounter interactCounter;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        
        Debug.Log(gameObject);
    }
}
