using Leopotam.Ecs;
using UnityEngine;

public class PlayerMoveSystem : IEcsRunSystem
{
    private EcsFilter<PlayerComponent> filter;

    private PlayerComponent playerComponent;
    public void Run()
    {
        foreach (var i in filter)
        {
            playerComponent = filter.Get1(i);
        }
        playerComponent.playerCharasterController.Move(playerComponent.moveDirection * playerComponent.moveSpeed * Time.deltaTime);
    }
}
