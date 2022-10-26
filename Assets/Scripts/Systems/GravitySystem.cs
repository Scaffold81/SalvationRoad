using Leopotam.Ecs;
using UnityEngine;

public class GravitySystem : IEcsRunSystem
{
    private GameData gameData;
    private EcsFilter<PlayerComponent> playerFilter;
    public void Run()
    {
        foreach (var i in playerFilter)
        {
            ref var playerComponent = ref playerFilter.Get1(i);

            playerComponent.moveDirection.y +=  gameData.physicsConfig.gravityValue * Time.deltaTime; ;


        }
    }
}
