using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInitSystem : IEcsInitSystem
{
    private EcsWorld ecsWorld;
    private GameData gameData;

    public void Init()
    {

        var playerEntity = ecsWorld.NewEntity();

        ref var playerComponent = ref playerEntity.Get<PlayerComponent>();

    }
}
