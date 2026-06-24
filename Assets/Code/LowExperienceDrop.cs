using System.Collections;
using UnityEngine;

public class LowExperienceDrop : ExperienceDrop
{
    public LowExperienceDrop()
    {
        Awake();
    }

    private void Awake()
    {
        SetExperiencePoints(1);
    }
}