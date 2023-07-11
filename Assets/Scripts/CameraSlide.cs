using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CameraSlide : MonoBehaviour
{
    private Vector3 _startPosition;
    private Camera _camera;
    private float _direction = 1;
    [SerializeField] private Button _warehouseButton;
    [SerializeField] private Transform _movableButtonTransform;
    [SerializeField] private Button _wallButton;

    private void Awake()
    {
        _camera = Camera.main;
        _wallButton.onClick.AddListener(Slide);
        _warehouseButton.onClick.AddListener(Slide);
        _startPosition = _movableButtonTransform.position;
        _warehouseButton.enabled = false;
        _wallButton.enabled = true;
    }

    public void Slide()
    {
        if (_direction == 1)
        {
            StartCoroutine(GoUp());

        }
        else
        {
            StartCoroutine(GoBack());
        }
    }

    private IEnumerator GoUp()
    {
        _warehouseButton.enabled = false;
        _wallButton.enabled = false;
        float progress = 0;
        Vector3 targetPosition = _camera.transform.position + _direction * new Vector3(19, 0, 0);
        Vector3 buttonPosition = _movableButtonTransform.position + _direction * new Vector3(19, 0, 0);
        _wallButton.gameObject.SetActive(_direction == 1 ? false : true);
        while (progress < 1)
        {
            //_buttonObject.transform.position = Vector3.Lerp(_buttonObject.transform.position, buttonPosition, progress);
            //_camera.transform.position = Vector3.Lerp(_camera.transform.position, targetPosition, progress);
            _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, targetPosition, progress);
            _movableButtonTransform.position = Vector3.MoveTowards(_movableButtonTransform.position, buttonPosition, progress);

            progress += Time.deltaTime;
            yield return null;
        }
        _wallButton.enabled = _direction == 1 ? false : true;

        _warehouseButton.enabled =  _direction == 1? true: false;   
        _direction *= -1;
    }

    private IEnumerator GoBack()
    {
        _warehouseButton.enabled = false;
        _wallButton.enabled = false;
        float progress = 0;
        Vector3 targetPosition = _camera.transform.position + _direction * new Vector3(19, 0, 0);
        _movableButtonTransform.position = _startPosition;

        while (progress < 1)
        {
            //_buttonObject.transform.position = Vector3.Lerp(_buttonObject.transform.position, buttonPosition, progress);
            //_camera.transform.position = Vector3.Lerp(_camera.transform.position, targetPosition, progress);
            _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, targetPosition, progress);

            progress += Time.deltaTime;
            yield return null;
        }

        _wallButton.gameObject.SetActive(_direction == 1 ? false : true);
        _wallButton.enabled = true;
        _warehouseButton.enabled = false;
        _direction *= -1;
    }
}
