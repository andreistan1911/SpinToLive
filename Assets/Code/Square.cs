using System.Collections;
using UnityEngine;


public class Square : Enemy
{
    protected override void SetStats()
    {
        stats.SetHealth(Constants.Square.Health);
        stats.SetSpeed(Constants.Square.Speed); 
        stats.SetDamage(Constants.Square.Damage);
        stats.SetExperienceDrop(Constants.Square.Exp);
    }

    protected override void DropExperience()
    {
        Instantiate(PrefabLoader.LowExperienceDrop, transform.position, Quaternion.identity);
    }
}
