using System.Collections;
using System.Collections.Generic;
using Unity.Serialization;
using UnityEngine;
using UnityEngine.Splines;

public class StorageManager : MonoBehaviour
{
    [SerializeField] GameObject _сargoObject;
    CargoMove cargoMove;
    Cargo cargo;
    Storage storage;
    UIScore score;

    private void Awake()
    {
        storage = GetComponent<Storage>();
        score = GetComponent<UIScore>();
        cargoMove = _сargoObject.GetComponent<CargoMove>();
        cargo = _сargoObject.GetComponent<Cargo>();
        score.Score(storage.ArrowCount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cargo"))
        {
            if (cargoMove.IsMoving())
            {
                cargoMove.StopCargo();
                cargoMove.ChangeDirection();
                if (cargo.IsLoad)
                {
                    cargo.UnloadCargo();
                    storage.AddArrows(cargo.MaxWeight);
                }

                cargoMove.MoveCargo();
                score.Score(storage.ArrowCount);
            }
        }
    }

    public void TakeArrow()
    {
        storage.SubtractArrow();
        score.Score(storage.ArrowCount);
    }

    public int GetArrowCount()
    {
        return storage.ArrowCount;
    }
}