using UnityEngine;
public class FactorySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;
    [SerializeField] private EnemyFactory factory;

    [Header("Configurations")]
    [SerializeField] private float spawnDistance = 10f;
    [SerializeField] private float spawnDelay = 2f;

    private float _timeElapsed = 0f;

    private void Update()
    {
        _timeElapsed += Time.deltaTime;

        if (_timeElapsed >= spawnDelay)
        {
            SpawnObject();
            _timeElapsed = 0f;
        }
    }

    private void SpawnObject()
    {
        Vector2 offset = Random.insideUnitCircle * spawnDistance;
        Vector3 spawnPosition = player.position + new Vector3(offset.x, 0f, offset.y);

        GameObject enemy = factory.GetEnemy();
        enemy.transform.position = spawnPosition;
        
        Destroy(enemy, 6f);
    }
}
