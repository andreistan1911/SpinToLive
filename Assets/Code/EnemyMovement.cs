using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3f;

    private Transform player;
    private Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        player = FindAnyObjectByType<PlayerMovement>()?.transform;

        if (player == null)
            Debug.LogError("There is no player object in scene!");
    }

    private void Update()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rigidBody.linearVelocity = direction * moveSpeed;
    }
}
