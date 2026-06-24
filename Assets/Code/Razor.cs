using UnityEngine;

public class Razor : Weapon
{
    private Vector2 direction;

    override public void Activate()
    {
        Enemy closestEnemy = FindTheClosestEnemy();

        if (closestEnemy == null)
        {
            // No enemies found, destroy the razor immediately
            Destroy(gameObject);
            return;
        }

        isAlive = true;
        direction = (closestEnemy.transform.position - transform.position).normalized;

        Destroy(gameObject, Constants.Razor.Lifetime);
    }

    override protected void Deactivate()
    {
        // Object is destroyed when it collides with an enemy or after maxLifeTime seconds, so no additional deactivation logic is needed here.
    }

    override protected void UpdateLocation()
    {
        transform.Translate(Constants.SpeedCoef * Constants.Razor.Speed * Time.deltaTime * direction);
    }

    // region Private Methods

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
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(Constants.Razor.Damage);
            isAlive = false;
        }
    }

    // endregion
}
