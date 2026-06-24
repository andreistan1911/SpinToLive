using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private Dictionary<WeaponType, float> weaponsLastUsageTime;

    private void Start()
    {
        weaponsLastUsageTime = new();

        weaponsLastUsageTime.Add(WeaponType.StraightLine, 0f);
    }

    private void Update()
    {
        if (HasWeapon(WeaponType.StraightLine))
            SpawnStraightLine();
    }
    
    private bool HasWeapon(WeaponType weaponType)
    {
        return weaponsLastUsageTime.ContainsKey(weaponType) && weaponsLastUsageTime[weaponType] >= 0f;
    }

    private bool CanUseWeapon(WeaponType weaponType)
    {
        return Time.time - weaponsLastUsageTime[weaponType] > Constants.Razor.Cooldown;
    }

    private void SpawnStraightLine()
    {
        if (CanUseWeapon(WeaponType.StraightLine))
        {
            Weapon weapon = Instantiate(PrefabLoader.Razor, transform.position, Quaternion.identity);
            weapon.Activate();
            weaponsLastUsageTime[WeaponType.StraightLine] = Time.time;
        }
    }


}
