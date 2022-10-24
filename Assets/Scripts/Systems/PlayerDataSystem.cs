
using UnityEngine;
using Leopotam.Ecs;
public class PlayerDataSystem : IEcsInitSystem,IEcsRunSystem
{
    private EcsWorld ecsWorld;
    private EcsEntity playerDataEntity;
    
    public delegate void OnLevelIndexChange(int value);
    public OnLevelIndexChange onLevelIndexChange;

    public void Init()
    {
      playerDataEntity=ecsWorld.NewEntity();
      ref var playerDataComponent= ref playerDataEntity.Get<PlayerDataComponent>();
        playerDataComponent.levelIndex = 0;
        playerDataComponent.subLevelIndex = 0;
    }
   
    public void LevelCange(int value)
    {
        ref var playerDataComponent = ref playerDataEntity.Get<PlayerDataComponent>();
        playerDataComponent.levelIndex = value;
        onLevelIndexChange(value);
    }
    public void Run()
    {
       
    }
}
