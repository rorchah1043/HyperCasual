using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class MoveCartAuthoring : MonoBehaviour
{
    public int Level;// = 0;
    public float MaxCargo;// = 6;
    public float TransferTime;// = 3;
    public float UpgradeCost;// = 6;

    public GameObject PointA;
    public GameObject PointB;
    public float MoveSpeed;// = 1f;
   

}

public class MoveCartBaker : Baker<MoveCartAuthoring>
{
    public override void Bake(MoveCartAuthoring authoring)
    {
        AddComponent(GetEntity(TransformUsageFlags.Dynamic), new MoveCart
        {
            Level = authoring.Level,
            MaxCargo = authoring.MaxCargo,
            TransferTime = authoring.TransferTime,
            UpgradeCost = authoring.UpgradeCost,
            MoveSpeed = authoring.MoveSpeed,

            PointA = authoring.PointA.transform.localPosition,
            PointB = authoring.PointB.transform.localPosition,
            TargetTransform = authoring.PointA.transform.localPosition
        });
    }
}
