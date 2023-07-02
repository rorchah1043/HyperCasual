using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float horizontalSpeed;
    public GameObject target;
    public Vector3 archerPosition;

    private Vector3 _targetPosition;

    private void Update()
    {
        var targetIsAlive = target != null;

        if (targetIsAlive)
        {
            _targetPosition = target.transform.position;
        }

        var x2 = XZ(_targetPosition - archerPosition).magnitude;
        var a = -(x2 + archerPosition.y - _targetPosition.y) / (x2 * x2);
        const int b = 1;
        var c = archerPosition.y;

        var x = XZ(transform.position - archerPosition).magnitude + horizontalSpeed * Time.deltaTime;

        if (x > x2)
        {
            if (targetIsAlive)
            {
                Destroy(target);
            }

            Destroy(gameObject);
        }
        else
        {
            var y = a * x * x + b * x + c;
            var horizontalPosition = XZ(archerPosition) + XZ(_targetPosition - archerPosition).normalized * x;
            transform.position = new Vector3(horizontalPosition.x, y, horizontalPosition.y);
        }
    }

    private Vector2 XZ(Vector3 vector)
    {
        return new Vector2(vector.x, vector.z);
    }
}