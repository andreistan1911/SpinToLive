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

    public static class Razor
    {
        public const float Cooldown = 2f;
        public const float Speed = 10f;
        public const float Lifetime = 5f;
        public const float Damage = 10f;
    }

    public static class Square
    {
        public const float Health = 20f;
        public const float Speed = 2f;
        public const float Damage = 1f;
        public readonly static LowExperienceDrop Exp;
    }
}
