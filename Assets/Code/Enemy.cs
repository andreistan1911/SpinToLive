using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public static readonly List<Enemy> ActiveEnemies = new();

    protected abstract void SetStats();

    [System.Serializable]
    public class Stats
    {
        public float Health;
        public float Speed;
        public float Damage;
        public ExperienceDrop Exp;

        public Stats(float health = 0f, float speed = 0f, float damage = 0f, ExperienceDrop exp = null)
        {
            Health = health;
            Speed = speed;
            Damage = damage;
            Exp = exp;
        }

        public void SetHealth(float health)
        {
            Health = health;
        }

        public void SetSpeed(float speed)
        {
            Speed = speed;
        }

        public void SetDamage(float damage)
        {
            Damage = damage;
        }

        public void SetExperienceDrop(ExperienceDrop exp)
        {
            Exp = exp;
        }
    }

    public Stats stats;

    private void OnEnable()
    {
        ActiveEnemies.Add(this);
    }

    private void OnDisable()
    {
        ActiveEnemies.Remove(this);
    }

    private void Start()
    {
        SetStats();
    }

    public void TakeDamage(float damage)
    {
        // TODO: Add visual feedback for taking damage (e.g., flashing red, playing a sound, etc.)
        stats.Health -= damage;

        Debug.Log($"{gameObject.name} took {damage} damage. Remaining health: {stats.Health}");
        if (stats.Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        DropExperience();
        Destroy(gameObject);
    }

    abstract protected void DropExperience();
}
