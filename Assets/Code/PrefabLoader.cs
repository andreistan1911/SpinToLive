using UnityEngine;

public static class PrefabLoader
{
    public static Square Square { get ; private set; }

    public static Razor Razor { get; private set; }
    public static Planet Planet { get; private set; }

    public static LowExperienceDrop LowExperienceDrop { get; private set; }

    private static bool isLoaded = false;

    // TODO: Load when main menu is loaded. for testing purposes, it will be in player script Start method

    public static void Load()
    {
        if (isLoaded)
            return;

        Square = Resources.Load<GameObject>("Prefabs/Enemies/Square").GetComponent<Square>();

        Razor = Resources.Load<Razor>("Prefabs/Weapons/Razor").GetComponent<Razor>();
        Planet = Resources.Load<Planet>("Prefabs/Weapons/Planet").GetComponent<Planet>();

        LowExperienceDrop = Resources.Load<LowExperienceDrop>("Prefabs/Experience/LowExp").GetComponent<LowExperienceDrop>();

        isLoaded = true;
    }
}
