using UnityEngine;

public class StraightLineWeapon : Weapon
{
    [SerializeField]
    private float speedCoefficient = 10f;

    [SerializeField]
    private float maxLifeTime = 30f;

    private Enemy closestEnemy;
    private bool isAlive = false;

    override public void Activate()
    {
        isAlive = true;
        closestEnemy = FindTheClosestEnemy();
        Destroy(gameObject, maxLifeTime);
    }

    override protected void Deactivate()
    {
        DestroyObjectOnCollideWithEnemy();
        // It also destroys itself after maxLifeTime seconds
    }

    override protected void UpdateLocation()
    {
        MoveTowardsEnemy(closestEnemy);
    }

    private Enemy FindTheClosestEnemy()
    {
        Enemy closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (Enemy enemy in Enemy.ActiveEnemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }
        return closestEnemy;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            isAlive = false;
        }
    }


    private void DestroyObjectOnCollideWithEnemy()
    {
        if (!isAlive)
        {
            Destroy(gameObject);
        }
    }

    private void MoveTowardsEnemy(Enemy enemy)
    {
        if (enemy != null)
        {
            Vector2 direction = (enemy.transform.position - transform.position).normalized;
            transform.Translate(speedCoefficient * Time.deltaTime * direction);
        }
    }
}
