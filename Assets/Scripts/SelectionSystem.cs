using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using Unity.Mathematics;
using Unity.Collections;
using Unity.Physics;
using Unity.Physics.Systems;

public partial class SelectionSystem : SystemBase
{
    private World _world;
    private Camera _mainCamera;
    private Entity _entity;
    private BuildPhysicsWorld  _buildPhysicsWorld;
    private CollisionWorld _collisionWorld;

    protected override void OnCreate()
    {
        //_world = World.DefaultGameObjectInjectionWorld;
        //_mainCamera = Camera.main;
        //BuildPhysicsWorld _buildPhysicsWorld = _world.GetOrCreateSystem<BuildPhysicsWorld>();
    }

    protected override void OnUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            SelectUnit();
        }
        
    }

    private void SelectUnit()
    {
        UnityEngine.Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        Debug.Log(ray.GetPoint(_mainCamera.farClipPlane));

        if(_world.IsCreated && !_world.EntityManager.Exists(_entity))
        {
            _entity = World.EntityManager.CreateEntity();
            World.EntityManager.AddBuffer<ClickPlacementInput>(_entity);
        }

        RaycastInput raycastInput = new RaycastInput()
        {
            Start = ray.origin,
            Filter = CollisionFilter.Default,
            End = Input.mousePosition
        };

        _world.EntityManager.GetBuffer<ClickPlacementInput>(_entity).Add(new ClickPlacementInput() { Value = raycastInput });
    }
}

public struct ClickPlacementInput: IBufferElementData
{
    public RaycastInput Value;
}
