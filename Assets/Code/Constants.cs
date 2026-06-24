using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Constants
{
    public static List<int> PlayerLevelExperienceRequirements = new()
    {
        0, // dummy value, as level 0 is ignored
        3,
        5,
        7,
        10,
        15,
        25,
        40,
        75,
        100,
        150,
        350,
        500,
        750,
        1000,
        1500,
        3000,
        5000,
        7500,
        10000,
        30000,
        int.MaxValue
    };

    public const float SpeedCoef = 0.05f;

    public static class Player
    {
        public const float MoveSpeed = 10f;
        public const float MaxHealth = 100f;
    }

    public static class Razor
    {
        public const float Lifetime = 5f;
        public const float Cooldown = 2f;
        public const float Speed = 10f;
        public const float Damage = 10f;
    }

    public static class Planet
    {
        public const float LifeTime = 5f;
        public const float Cooldown = LifeTime + 3f;
        public const float Omega = Mathf.PI;
        public const float Damage = 5f;
        public const float Radius = 150f;
        public const int NumberOfPlanets = 3;
    }

    public static class Square
    {
        public const float Health = 20f;
        public const float Speed = 2f;
        public const float Damage = 1f;
        public readonly static LowExperienceDrop Exp;
    }
}
