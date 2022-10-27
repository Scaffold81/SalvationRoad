using Leopotam.Ecs;
using UnityEngine;

public class ChassisRotateSystem : IEcsRunSystem
{
    private EcsFilter<PlayerComponent> filter;

    private PlayerComponent playerComponent;
    public void Run()
    {
        foreach (var f in filter)
        {
            ref var _playerComponent = ref filter.Get1(f);
            playerComponent = _playerComponent;
        }
        Vector3 newDirection = Vector3.RotateTowards(playerComponent.playerChassisTransform.forward, new Vector3(playerComponent.moveDirection.x, 0, playerComponent.moveDirection.z), 8 * Time.deltaTime, 0.0f);
        playerComponent.playerChassisTransform.rotation = Quaternion.LookRotation(newDirection);

    }


}
