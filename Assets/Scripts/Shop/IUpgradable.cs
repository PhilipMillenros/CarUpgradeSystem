using UnityEngine;

public abstract class Upgradeable<T> : MonoBehaviour where T : MonoBehaviour
{
    public T[] upgradeVariants;
}