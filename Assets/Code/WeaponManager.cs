using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private Weapon StraightLineWeaponPrefab;

    private Dictionary<WeaponType, bool> ownedWeapons;

    private void Start()
    {
        ownedWeapons = new();

        ownedWeapons.Add(WeaponType.StraightLine, true);
    }

    private void Update()
    {
        if (ownedWeapons[WeaponType.StraightLine])
        {
            Weapon newWeapon = Instantiate(StraightLineWeaponPrefab);

            newWeapon.Activate();

            ownedWeapons[WeaponType.StraightLine] = false;
        }
   
    }
}
