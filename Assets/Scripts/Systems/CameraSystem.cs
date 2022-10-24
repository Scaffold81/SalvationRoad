using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsWorld ecsWorld;
    private GameData gameData;
    private EcsEntity cameraEntity;
    private EcsFilter<PlayerComponent> playerFilter;

    public void Init()
    {
        var cameraEntity = ecsWorld.NewEntity();

        ref var cameraComponent = ref cameraEntity.Get<CameraComponent>();

        cameraComponent.cameraTransform = Camera.main.transform;
        cameraComponent.cameraFollowSmoothness = gameData.cameraConfig.cameraFollowSmoothness;
        cameraComponent.cameraCurrentVelocity = Vector3.zero;
        cameraComponent.cameraOffset = gameData.cameraConfig.cameraOffset;

        this.cameraEntity = cameraEntity;
    }

    public void Run()
    {
        if (!cameraEntity.IsAlive()) return;
        ref var cameraComponent = ref cameraEntity.Get<CameraComponent>();

        foreach (var i in playerFilter)
        {
            ref var playerComponent = ref playerFilter.Get1(i);

            Vector3 currentPosition = cameraComponent.cameraTransform.position;
            Vector3 targetPoint = playerComponent.playerTransform.position + cameraComponent.cameraOffset;

            cameraComponent.cameraTransform.position = Vector3.SmoothDamp(currentPosition, targetPoint, ref cameraComponent.cameraCurrentVelocity, cameraComponent.cameraFollowSmoothness);
        }
    }
}