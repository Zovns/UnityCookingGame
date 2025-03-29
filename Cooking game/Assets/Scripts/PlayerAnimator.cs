using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    [SerializeField]private PlayerController playerController;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("IsWalking", playerController.IsWalking());
    }
}
