using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UIElements;

public class SyncWithBodyMovement : MonoBehaviour
{
    private SpriteRenderer faceSpriteRenderer;
    private SpriteRenderer bodySpriteRenderer;
    private Animator bodyAnimator;
    private Vector3 initialPosition;

    private Vector3 movingHeadPosition = new(0, -20f, -0.1f);

    private static readonly int MovingHash = Animator.StringToHash("Moving");
    private static readonly int IdleFrontHash = Animator.StringToHash("Idle Front");
    private static readonly int HunchFrontHash = Animator.StringToHash("Hunch Front");
    private static readonly int WalkingFrontHash = Animator.StringToHash("Walking Front");
    private static readonly int HunchFrontToIdleHash = Animator.StringToHash("Hunch Front To Idle");


    private void Awake()
    {
        faceSpriteRenderer = GetComponent<SpriteRenderer>();
        bodySpriteRenderer = transform.parent.GetComponent<SpriteRenderer>();
        bodyAnimator = transform.parent.GetComponent<Animator>();
        initialPosition = transform.localPosition;

        Debug.Assert(bodySpriteRenderer != null, "Body SpriteRenderer is not assigned.");
        Debug.Assert(bodyAnimator != null, "Body Animator is not assigned.");
        Debug.Assert(faceSpriteRenderer != null, "Face SpriteRenderer is not assigned.");
        Debug.Assert(initialPosition != null, "Initial position is not assigned.");
    }

    private void LateUpdate()
    {
        SetFaceActive();
        if (faceSpriteRenderer.enabled)
        {
            SyncWithHead();
        }
    }

    private void SetFaceActive()
    {

        AnimatorStateInfo currentState =
            bodyAnimator.GetCurrentAnimatorStateInfo(0);

        AnimatorStateInfo nextState =
            bodyAnimator.GetNextAnimatorStateInfo(0);

        if (bodyAnimator.IsInTransition(0) && !nextState.IsName("Idle Front"))
        {
            faceSpriteRenderer.enabled = false;
            return;
        }

        faceSpriteRenderer.enabled =
            currentState.IsName("Idle Front") ||
            currentState.IsName("Walking Front");

        Debug.Log(faceSpriteRenderer.enabled);
    }

    private Vector3 SyncWithHeadPosition(bool isMoving)
    {
        if (isMoving)
            return movingHeadPosition;

        return initialPosition;
    }

    private void SyncWithHead()
    {
        int frame = GetFrameIndex(bodySpriteRenderer.sprite.name);

        float offsetY = frame switch
        {
            0 => 0f,
            1 => -1f,
            2 => -2f,
            3 => -3f,
            4 => -2f,
            5 => -1f,
            6 => 0f,
            7 => 0f,
            _ => 0f
        };

        transform.localPosition = SyncWithHeadPosition(bodyAnimator.GetBool(MovingHash)) + Vector3.up * offsetY;
    }

    private int GetFrameIndex(string spriteName)
    {
        return spriteName[^1] - '0';
    }
}
