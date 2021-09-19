using UnityEngine;

public abstract class EnemyFactory : MonoBehaviour
{
    [SerializeField] protected GameObject baseEnemy;
    public abstract GameObject GetEnemy();
}
