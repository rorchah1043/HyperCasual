using JetBrains.Annotations;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public StorageManager arrowStorage;
    public Arrow arrowPrefab;
    public float shootPeriod;

    private float _lastShotTimestamp;

    private void Update()
    {
        var closestEnemy = FindClosestEnemy();
        if (closestEnemy == null) return;

        var lookDirection = closestEnemy.transform.position - transform.position;
        lookDirection.y = 0;
        transform.rotation = Quaternion.LookRotation(lookDirection);
        
        if (Time.time - _lastShotTimestamp < shootPeriod || arrowStorage.GetArrowCount() <= 0) return;

        Shoot(closestEnemy.gameObject);
    }

    [CanBeNull]
    private Enemy FindClosestEnemy()
    {
        var enemies = FindObjectsOfType<Enemy>();

        var minDistance = float.PositiveInfinity;
        Enemy closestEnemy = null;

        var position = transform.position;
        foreach (var enemy in enemies)
        {
            var distance = Vector3.Distance(position, enemy.transform.position);
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