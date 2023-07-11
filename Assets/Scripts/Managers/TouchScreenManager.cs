using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchScreenManager : MonoBehaviour
{
    [SerializeField] bool manyTapTriger;
    [SerializeField] CargoMove cargo;
    [SerializeField] private CameraController cameraController;
    private PlayerInput _playerInput;

    private Camera _mainCamera;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _mainCamera = Camera.main;
    }

    private void OnTouchPosition(InputValue value)
    {
        Ray ray = _mainCamera.ScreenPointToRay(Pointer.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Cargo"))
            {
                ToMoveCargo(hit.collider.GetComponent<CargoMove>());
            }
            else if (hit.collider.CompareTag("Wall"))
            {
                cameraController.ToggleMove();
            }
        }
    }

    private void ToMoveCargo(CargoMove cargoMove)
    {
        cargoMove.MoveCargo();
        if (cargoMove.IsMoving() && manyTapTriger)
        {
            cargoMove.SpeedUp();
        }
    }
}