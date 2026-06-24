using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerAnimationController))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private PlayerAnimationController animationController;
    private Rigidbody2D rigidBody;
    private Vector2 movement;

    private void Start()
    {
        animationController = GetComponent<PlayerAnimationController>();
        rigidBody = GetComponent<Rigidbody2D>();

        // TODO: REMOVE FROM HERE
        PrefabLoader.Load();
    }

    private void Update()
    {
        GetInput();
        animationController.UpdateMovement(movement);

        rigidBody.linearVelocity = Constants.SpeedCoef * Constants.Player.MoveSpeed * movement;
    }

    private void GetInput()
    {
        movement = Keyboard.current != null 
            ? new Vector2(
                Keyboard.current.dKey.isPressed ? 1 :
                Keyboard.current.aKey.isPressed ? -1 : 0,

                Keyboard.current.wKey.isPressed ? 1 :
                Keyboard.current.sKey.isPressed ? -1 : 0)
            : Vector2.zero;

        movement.Normalize();
    }
}
