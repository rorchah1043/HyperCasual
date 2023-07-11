using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour
{
    [SerializeField] private int _maxWeight;
    [SerializeField] private bool _isLoaded;

    [SerializeField] private float _speedCargo;

    public float Speed => _speedCargo;

    public bool IsLoad => _isLoaded;
    public int MaxWeight => _maxWeight;

    public void LoadCargo() => _isLoaded = true;
    public void UnloadCargo() => _isLoaded = false;
}