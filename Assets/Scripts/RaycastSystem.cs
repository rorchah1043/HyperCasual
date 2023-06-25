using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using Unity.Burst;
using Unity.Physics;
using Unity.Physics.Systems;

[UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
//[UpdateAfter(typeof(PhysicsSimulationGroup))]
[BurstCompile]

public partial struct RaycastSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {

    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {

    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        PhysicsWorldSingleton physicsWorldSingleton = SystemAPI.GetSingleton<PhysicsWorldSingleton>();

        foreach (var input in SystemAPI.Query<DynamicBuffer<ClickPlacementInput>>())
        {
            foreach (var placementInput in input)
            {
                if (physicsWorldSingleton.CastRay(placementInput.Value, out Unity.Physics.RaycastHit hit))
                {
                    Debug.Log($"{hit.Position}");
                }
            }
            input.Clear();
        }
    }
}
