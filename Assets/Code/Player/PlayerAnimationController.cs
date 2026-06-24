using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    private bool facingFront = true;

    private static readonly int MovingHash = Animator.StringToHash("Moving");
    private static readonly int FacingFrontHash = Animator.StringToHash("FacingFront");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void UpdateMovement(Vector2 movement)
    {
        bool moving = movement.sqrMagnitude > 0.01f;

        animator.SetBool(MovingHash, moving);

        if (moving)
        {
            if (movement.y > 0)
            {
                facingFront = false;
            }
            else if (movement.y < 0)
            {
                facingFront = true;
            }

            animator.SetBool(FacingFrontHash, facingFront);
        }
    }
}
