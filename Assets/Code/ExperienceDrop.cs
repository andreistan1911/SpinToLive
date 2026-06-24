using System.Collections;
using UnityEngine;


public abstract class ExperienceDrop : MonoBehaviour
{
    protected int ExperiencePoints { get; private set; }

    protected void SetExperiencePoints(int points)
    {
        ExperiencePoints = points;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // TODO
        PlayerExperience playerExperience = collision.GetComponent<PlayerExperience>();

        if (playerExperience == null)
            return;

        playerExperience.AddExperience(ExperiencePoints);

        Destroy(gameObject);
    }
}