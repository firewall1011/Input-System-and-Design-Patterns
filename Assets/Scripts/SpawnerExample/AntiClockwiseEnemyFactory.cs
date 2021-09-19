using UnityEngine;

public class AntiClockwiseEnemyFactory : EnemyFactory
{
    public override GameObject GetEnemy()
    {
        GameObject enemy = Instantiate(baseEnemy);
        enemy.AddComponent<AntiClockwiseRotator>();

        return enemy;
    }
}
