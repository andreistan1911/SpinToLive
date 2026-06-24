using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceUI : MonoBehaviour
{
    [SerializeField]
    private Image experienceBar;

    [SerializeField]
    private TMP_Text levelText;

    private Vector3 scale;
    private float maxXscale;

    private void Start()
    {
        scale = experienceBar.rectTransform.localScale;
        maxXscale = scale.x;

        UpdateInfo();
    }

    public void UpdateInfo()
    {
        PlayerExperience playerExperience = FindAnyObjectByType<PlayerExperience>();
        if (playerExperience == null)
            return;

        int currentLevel = playerExperience.GetCurrentLevel();
        int currentExperience = playerExperience.GetCurrentExperience();
        int experienceRequired = playerExperience.GetExperienceRequired();

        float percentage = (float)currentExperience / experienceRequired;
        float currentXscale = maxXscale * percentage;

        scale.x = currentXscale;
        experienceBar.rectTransform.localScale = scale;

        levelText.text = "Level: " + currentLevel;
    }
}
