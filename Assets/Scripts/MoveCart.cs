using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public partial struct MoveCart : IComponentData
{
    public int Level;// = 0;
    public float MaxCargo;// = 6;
    public float TransferTime;// = 3;
    public float UpgradeCost;// = 6;

    public float3 PointA;
    public float3 PointB;
    public float3 TargetTransform;
    public float MoveSpeed;// = 1f;
}
