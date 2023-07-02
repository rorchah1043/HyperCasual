using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CaveManager : MonoBehaviour
{
    [SerializeField] GameObject _cargoObject;
    CargoMove cargoMove;
    Cargo cargo;

    private void Awake()
    {
        cargoMove = _cargoObject.GetComponent<CargoMove>();
        cargo = _cargoObject.GetComponent<Cargo>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cargo"))
        {
            if (cargoMove.IsMoving())
            {
                cargoMove.StopCargo();
                cargoMove.ChangeDirection();
                cargo.LoadCargo();
            }
        }
    }
}
