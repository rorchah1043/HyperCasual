using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnPeriod;
    public GameObject enemyPrefab;
    public GameObject wall;

    private float _lastSpawnTime;

    private void Update()
    {
        if (Time.time > _lastSpawnTime + spawnPeriod)
        {
            Spawn();
            _lastSpawnTime = Time.time;
        }
    }

    private void Spawn()
    {
        var enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemy.GetComponent<Enemy>().wall = wall;
    }
}