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
    private CameraComponent cameraComponent;
    private PlayerComponent playerComponent;

    public void Init()
    {
        var cameraEntity = ecsWorld.NewEntity();

        cameraComponent = cameraEntity.Get<CameraComponent>();

        cameraComponent.cameraTransform = Camera.main.transform;
        cameraComponent.cameraFollowSmoothness = gameData.cameraConfig.cameraFollowSmoothness;
        cameraComponent.cameraCurrentVelocity = Vector3.zero;
        cameraComponent.cameraOffset = gameData.cameraConfig.cameraOffset;

        this.cameraEntity = cameraEntity;

        foreach (var i in playerFilter)
        {
            playerComponent = playerFilter.Get1(i);
        }
        CameraFollow(0);
        MonoBehaviour.print(message:"Camera system initialize") ;
    }
    public void Run()
    {
        CameraFollow(cameraComponent.cameraFollowSmoothness);
    }
    void CameraFollow(float cameraFollowSmoothness)
    {
        if (!cameraEntity.IsAlive()) return;

        Vector3 currentPosition = cameraComponent.cameraTransform.position;
        Vector3 targetPoint = playerComponent.playerTransform.position + cameraComponent.cameraOffset;
        Vector3 targetDirection = playerComponent.playerTransform.position - targetPoint;

        cameraComponent.cameraTransform.position = Vector3.SmoothDamp(currentPosition, targetPoint, ref cameraComponent.cameraCurrentVelocity, cameraFollowSmoothness);
        cameraComponent.cameraTransform.forward = targetDirection;
    }
}
