using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using System;

public partial class MoveSystem : SystemBase//ISystem для большей производительности
{
   protected override void OnUpdate()
   {
        foreach (var (localTransform,moveCart) in SystemAPI.Query<RefRW<LocalTransform>,RefRW<MoveCart>>())
        {
            var direction = math.normalize(moveCart.ValueRO.TargetTransform- localTransform.ValueRO.Position);
            localTransform.ValueRW.Position += direction * SystemAPI.Time.DeltaTime * moveCart.ValueRO.MoveSpeed;

            if (math.distance(localTransform.ValueRO.Position,moveCart.ValueRO.PointB) < 1)
            {
                moveCart.ValueRW.TargetTransform = moveCart.ValueRO.PointA;
            }
            else if (math.distance(localTransform.ValueRO.Position, moveCart.ValueRO.PointA) < 1)
            {
                moveCart.ValueRW.TargetTransform = moveCart.ValueRO.PointB;
            }
        }

    }
}
