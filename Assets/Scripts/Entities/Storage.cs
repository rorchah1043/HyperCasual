using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    [SerializeField] private int _arrowCount;

    public int ArrowCount { get => _arrowCount; }

    public void AddArrows(int value) => _arrowCount += value;

    public void SubtractArrow() => _arrowCount--;
}
