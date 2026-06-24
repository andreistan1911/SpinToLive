using System.Collections;
using UnityEngine;


public abstract class ExperienceDrop : MonoBehaviour
{
    protected int ExperiencePoints { get; private set; }

    private ExperienceUI experienceUI;

    private void Start()
    {
        experienceUI = FindAnyObjectByType<ExperienceUI>();

        if (experienceUI == null)
            Debug.LogError("ExperienceUI not found in the scene. Please ensure there is an ExperienceUI component in the scene.");
    }

    protected void SetExperiencePoints(int points)
    {
        ExperiencePoints = points;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerExperience playerExperience = collision.GetComponent<PlayerExperience>();

        if (playerExperience == null)
            return;

        playerExperience.AddExperience(ExperiencePoints);
        experienceUI.UpdateInfo();
        
        Destroy(gameObject);
    }
}