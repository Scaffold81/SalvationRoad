using Leopotam.Ecs;
using UnityEngine;

public class PlayerSystem : IEcsInitSystem,IEcsRunSystem
{
    private EcsFilter<PlayerComponent> filter;

    private PlayerComponent playerComponent;
    public void Init()
    {
        foreach (var i in filter)
        {
            playerComponent = filter.Get1(i);
        }

    }
    public void Run()
    {
        
      
    }
}
