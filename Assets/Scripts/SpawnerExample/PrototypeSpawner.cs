using UnityEngine;
public class PrototypeSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform player;

    [Header("Configurations")]
    [SerializeField] private float spawnDistance = 10f;
    [SerializeField] private float spawnDelay = 2f;
    
    private float _timeElapsed = 0f;

    private void Update()
    {
        _timeElapsed += Time.deltaTime;
        
        if(_timeElapsed >= spawnDelay)
        {
            SpawnObject();
            _timeElapsed = 0f;
        }
    }

    private void SpawnObject()
    {
        Vector2 offset = Random.insideUnitCircle * spawnDistance;
        Vector3 spawnPosition = player.position + new Vector3(offset.x, 0f, offset.y);
        
        GameObject enemy = Instantiate(prefab, spawnPosition, Quaternion.identity);
        
        Destroy(enemy, 6f);
    }
}
