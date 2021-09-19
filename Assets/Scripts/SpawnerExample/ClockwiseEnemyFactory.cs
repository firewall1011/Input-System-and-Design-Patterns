using UnityEngine;

public class ClockwiseEnemyFactory : EnemyFactory
{
    public override GameObject GetEnemy()
    {
        GameObject enemy = Instantiate(baseEnemy);
        enemy.AddComponent<ClockwiseRotator>();
        
        return enemy;
    }
}