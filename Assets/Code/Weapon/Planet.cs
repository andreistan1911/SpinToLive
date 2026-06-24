using JetBrains.Annotations;
using UnityEngine;

public class Planet : Weapon
{
    private int index;

    override public void Activate()
    {
        isAlive = true;

        float angle = index * 2 * Mathf.PI / Constants.Planet.NumberOfPlanets;

        transform.localPosition = new Vector3(
            Constants.Planet.Radius * Mathf.Cos(angle),
            Constants.Planet.Radius * Mathf.Sin(angle),
            0f);

        Destroy(gameObject, Constants.Planet.LifeTime);
    }

    override protected void Deactivate()
    {
        // Object is destroyed when it collides with an enemy or after maxLifeTime seconds, so no additional deactivation logic is needed here.
    }

    override protected void UpdateLocation()
    {
        transform.RotateAround(
            transform.parent.position,
            Vector3.forward,
            Constants.Planet.Omega * Mathf.Rad2Deg * Time.deltaTime
        );
    }

    // region Private Methods

    public void SetIndex(int index)
    {
        this.index = index;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(Constants.Planet.Damage);
        }
    }

    // endregion
}
