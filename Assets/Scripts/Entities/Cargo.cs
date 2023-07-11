using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour
{
    [SerializeField] private int _maxWeight;
    [SerializeField] private bool _isLoaded;

    [SerializeField] private float _speedCargo;

    public float Speed { get => _speedCargo; }

    public bool IsLoad { get => _isLoaded; }
    public int MaxWeight { get => _maxWeight; }

    public void LoadCargo() => _isLoaded = true;

}
