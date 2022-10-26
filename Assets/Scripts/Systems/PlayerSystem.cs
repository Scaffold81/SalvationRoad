using Leopotam.Ecs;
using UnityEngine;

public class PlayerSystem : IEcsInitSystem,IEcsRunSystem
{
    private EcsWorld ecsWorld;
    private GameData gameData;

    
    private EcsFilter<PlayerComponent> filter;
   
    private PlayerComponent playerComponent;
   

    public void Init()
    {
        
        MonoBehaviour.print("Player system initialize");
    }
    public void Run()
    { foreach (var i in filter)
        {
            playerComponent = filter.Get1(i);
        }
        playerComponent.moveDirection.y += -10 * Time.deltaTime;
        playerComponent.playerCharasterController.Move(playerComponent.moveDirection * 10 * Time.deltaTime);
    }
}
