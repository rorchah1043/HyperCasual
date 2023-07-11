using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchScreenManager : MonoBehaviour
{
    [SerializeField] bool _ManyTapTriger;
    [SerializeField] CargoMove _cargo;
    private PlayerInput playerInput;

    private Camera mainCamera;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        mainCamera = Camera.main;
    }

    private void OnTouchPosition(InputValue value)
    {
        ToMoveCargo(value);
        SpeedUpCargo();
    }

    private void ToMoveCargo(InputValue value)
    {
        Ray ray = mainCamera.ScreenPointToRay(Pointer.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Cargo"))
            {
                hit.collider.GetComponent<CargoMove>().MoveCargo();
            }
        }
    }

    private void SpeedUpCargo()
    {
        if(_cargo.IsMoving() & _ManyTapTriger)
        {
            _cargo.SpeedUp();
        }
    }
}
