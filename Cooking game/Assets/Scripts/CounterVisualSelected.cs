using UnityEngine;

public class CounterVisualSelected : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject selectedMesh;
   public void SetSelected(bool isSelected)
    {
        selectedMesh.SetActive(isSelected);
    }
}
