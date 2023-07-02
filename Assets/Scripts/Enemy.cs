using JetBrains.Annotations;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public GameObject wall;

    [CanBeNull] private Wall _wallScript;

    private void Start()
    {
        if (wall.GetComponent<Collider>() == null)
        {
            Debug.LogError("Wall must have Collider attached");
        }

        _wallScript = wall.GetComponent<Wall>();
        if (_wallScript == null)
        {
            Debug.LogError("Wall must have Wall script attached");
        }
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, wall.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == wall)
        {
            Destroy(gameObject);

            if (_wallScript != null) _wallScript.Damage(1);
        }
    }
}