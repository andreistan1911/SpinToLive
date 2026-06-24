using UnityEngine;

internal class PlayerExperience : MonoBehaviour
{
    private int currentLevel;
    private int currentExperience;
    private int experienceRequired;

    private void Start() 
    {
        currentLevel = 1;
        currentExperience = 0;
        experienceRequired = Constants.PlayerLevelExperienceRequirements[1];
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public int GetCurrentExperience()
    {
        return currentExperience;
    }

    public int GetExperienceRequired()
    {
        return experienceRequired;
    }

    public void AddExperience(int bonusExp)
    {
        currentExperience += bonusExp;

        if (currentExperience >= experienceRequired)
        {
            currentExperience -= experienceRequired;
            experienceRequired = Constants.PlayerLevelExperienceRequirements[++currentLevel];
        }

        Debug.Log("Adding Experience: " + bonusExp + "\nCurrent Level: " + currentLevel + ", Current Experience: " + currentExperience + " / " + experienceRequired);
    }
}