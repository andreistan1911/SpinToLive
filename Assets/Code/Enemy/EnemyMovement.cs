using UnityEngine;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    private float moveSpeed;

    private Transform player;
    private Rigidbody2D rigidBody;

    private void Start()
    {
        moveSpeed = GetComponent<Enemy>().stats.Speed;
        rigidBody = GetComponent<Rigidbody2D>();
        player = FindAnyObjectByType<PlayerMovement>()?.transform;

        if (player == null)
            Debug.LogError("There is no player object in scene!");
    }

    private void Update()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rigidBody.linearVelocity = Constants.SpeedCoef * moveSpeed * direction;
    }
}
