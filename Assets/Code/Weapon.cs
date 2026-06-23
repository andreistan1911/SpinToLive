using System.Collections;
using UnityEngine;

abstract public class Weapon : MonoBehaviour
{
    abstract public void Activate();
    abstract protected void Deactivate();
    abstract protected void UpdateLocation();
}
