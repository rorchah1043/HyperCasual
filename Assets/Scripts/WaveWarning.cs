using UnityEngine;

public class WaveWarning : MonoBehaviour
{
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private GameObject warningObject;

    [SerializeField] private float blinkOnDuration;
    [SerializeField] private float blinkOffDuration;

    private float _lastBlinkTime = float.NegativeInfinity;

    private void Update()
    {
        if (enemySpawner.IsWave())
        {
            var lastBlinkTimeAgo = Time.time - _lastBlinkTime;
            if (lastBlinkTimeAgo > blinkOnDuration + blinkOffDuration)
            {
                _lastBlinkTime = Time.time;
                warningObject.SetActive(true);
            }
            else if (lastBlinkTimeAgo > blinkOnDuration)
            {
                warningObject.SetActive(false);
            }
            else
            {
                warningObject.SetActive(true);
            }
        }
        else
        {
            warningObject.SetActive(false);
        }
    }
}