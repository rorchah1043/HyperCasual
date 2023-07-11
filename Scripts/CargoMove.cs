using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class CargoMove : MonoBehaviour
{
    [SerializeField] private SplineContainer _spline;
    [SerializeField] private float _speedRatio;
    private Cargo _cargo;

    private bool _isMoving;
    private bool _isDirectionToCave;

    [SerializeField] private float _speed;
    private float _distancePercentage = 0f;
    private float _splineLength;

    private void Awake()
    {
        _cargo = GetComponent<Cargo>();
        _speed = _cargo.Speed;
        _isMoving = false;
        _splineLength = _spline.CalculateLength();
        _isDirectionToCave = true;
    }

    private void Update()
    {
        if(_isMoving)
        {
            if (_isDirectionToCave)
            {
                MoveForward();
            }
            else
            {
                MoveBack();
            }
      
        }
        
    }
    public void ChangeDirection()
    {
        _isDirectionToCave = !_isDirectionToCave;
    }

    public bool IsMoving() => _isMoving;

    public void MoveCargo()
    {
        _isMoving = true;
    }

    public void StopCargo()
    {
        _isMoving = false;
        _speed = _cargo.Speed;
    }

    public void SpeedUp()
    {
        _speed += _speedRatio;
    }

    private void MoveForward()
    {
        _distancePercentage += _speed * Time.deltaTime / _splineLength;

        Vector3 currentPosition = _spline.EvaluatePosition(_distancePercentage);
        transform.position = currentPosition;

        if (_distancePercentage > 1f)
        {
            _distancePercentage = 0f;
        }

        Vector3 nextPosition = _spline.EvaluatePosition(_distancePercentage + 0.05f);
        Vector3 direction = nextPosition - currentPosition;
        transform.rotation = Quaternion.LookRotation(direction, transform.up);
    }

    private void MoveBack()
    {
        _distancePercentage -= _speed * Time.deltaTime / _splineLength;

        Vector3 currentPosition = _spline.EvaluatePosition(_distancePercentage);
        transform.position = currentPosition;

        if (_distancePercentage < 0f)
        {
            _distancePercentage = 1f;
        }

        Vector3 nextPosition = _spline.EvaluatePosition(_distancePercentage - 0.05f);
        Vector3 direction = nextPosition - currentPosition;
        transform.rotation = Quaternion.LookRotation(direction, transform.up);
    }
}
