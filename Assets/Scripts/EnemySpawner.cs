using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject wall;

    public float spawnFrequency;
    public float spawnFrequencyAcceleration;

    public float waveLength;
    public float waveMultiplier;
    public float wavePeriod;

    private float _lastSpawnTime = float.NegativeInfinity;
    private float _lastWaveStartTime;

    private void Update()
    {
        if (Time.time - _lastWaveStartTime > wavePeriod)
        {
            _lastWaveStartTime = Time.time;
        }

        if (Time.time > _lastSpawnTime + 1 / (spawnFrequency * (IsWave() ? waveMultiplier : 1)))
        {
            Spawn();
            _lastSpawnTime = Time.time;
        }

        spawnFrequency += spawnFrequencyAcceleration * Time.deltaTime;
    }

    private void Spawn()
    {
        var enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemy.GetComponent<Enemy>().wall = wall;
    }

    public bool IsWave()
    {
        return Time.time - _lastWaveStartTime < waveLength;
    }
}