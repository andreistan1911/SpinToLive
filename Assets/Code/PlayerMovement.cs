using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    private Rigidbody2D rigidBody;
    private Vector2 movement;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetInput();


        rigidBody.linearVelocity = movement * moveSpeed;
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
