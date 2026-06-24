using System.Collections;
using UnityEngine;

abstract public class Weapon : MonoBehaviour
{
    abstract public void Activate();
    abstract protected void Deactivate();
    abstract protected void UpdateLocation();

    protected bool isAlive = false;

    private void Update()
    {
        UpdateLocation();
        DestroyIfNotAlive();
    }

    private void DestroyIfNotAlive()
    {
        if (!isAlive)
        {
            Destroy(gameObject);
        }
    }
}
