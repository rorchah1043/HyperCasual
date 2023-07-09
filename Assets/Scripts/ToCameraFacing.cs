using UnityEngine;

public class ToCameraFacing : MonoBehaviour
{
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }
    private void Update()
    {
        transform.LookAt(new Vector3(_camera.transform.position.x, _camera.transform.position.y, transform.position.z));
    }
}
