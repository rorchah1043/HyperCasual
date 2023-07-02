using JetBrains.Annotations;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public ArrowStorageMock arrowStorage;
    public Arrow arrowPrefab;
    public float shootPeriod;

    private float _lastShotTimestamp;

    private void Update()
    {
        if (Time.time - _lastShotTimestamp < shootPeriod || !arrowStorage.HasArrowsAvailable()) return;

        var closestEnemy = FindClosestEnemy();
        if (closestEnemy == null) return;

        Shoot(closestEnemy.gameObject);
    }

    [CanBeNull]
    private Enemy FindClosestEnemy()
    {
        var enemies = FindObjectsOfType<Enemy>();

        var minDistance = float.PositiveInfinity;
        Enemy closestEnemy = null;

        foreach (var enemy in enemies)
        {
            var distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }

    private void Shoot(GameObject target)
    {
        arrowStorage.TakeArrow();
        _lastShotTimestamp = Time.time;
        
        var position = transform.position;
        var arrow = Instantiate(arrowPrefab, position, Quaternion.identity);
        arrow.archerPosition = position;
        arrow.target = target;
    }
}