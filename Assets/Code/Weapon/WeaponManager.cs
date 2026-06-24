using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private Dictionary<WeaponType, float> weaponsLastUsageTime;

    private void Start()
    {
        weaponsLastUsageTime = new();

        weaponsLastUsageTime.Add(WeaponType.Razor, -1000f);
        weaponsLastUsageTime.Add(WeaponType.Planet, -Constants.Planet.Cooldown);
    }

    private void Update()
    {
        if (HasWeapon(WeaponType.Razor))
            SpawnRazor();
        if (HasWeapon(WeaponType.Planet))
            SpawnPlanet();
    }
    
    private bool HasWeapon(WeaponType weaponType)
    {
        return weaponsLastUsageTime.ContainsKey(weaponType) && weaponsLastUsageTime[weaponType] > -1000f;
    }

    private float CooldownByWeaponType(WeaponType weaponType)
    {
        return weaponType switch
        {
            WeaponType.Razor => Constants.Razor.Cooldown,
            WeaponType.Planet => Constants.Planet.Cooldown,
            _ => 0.1f
        };
    }

    private bool CanUseWeapon(WeaponType weaponType)
    {
        //Debug.Log($"Weapon: {weaponType}, Last Usage Time: {weaponsLastUsageTime[weaponType]}, Current Time: {Time.time}, Cooldown: {CooldownByWeaponType(weaponType)}");
        return Time.time - weaponsLastUsageTime[weaponType] > CooldownByWeaponType(weaponType);
    }

    private void SpawnRazor()
    {
        if (CanUseWeapon(WeaponType.Razor))
        {
            Razor weapon = Instantiate(PrefabLoader.Razor, transform.position, Quaternion.identity);
            weapon.Activate();
            weaponsLastUsageTime[WeaponType.Razor] = Time.time;
        }
    }

    private void SpawnPlanet()
    {
        if (CanUseWeapon(WeaponType.Planet))
        {
            for (int i = 0; i < Constants.Planet.NumberOfPlanets; i++)
            {
                Planet weapon = Instantiate(PrefabLoader.Planet, transform.position, Quaternion.identity);
                weapon.transform.SetParent(transform);
                weapon.SetIndex(i);
                weapon.Activate();
            }
            weaponsLastUsageTime[WeaponType.Planet] = Time.time;
        }
    }
}
