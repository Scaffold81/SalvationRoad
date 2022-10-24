using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class SpawnSystem :IEcsInitSystem
{
    FabricaSystem fabricaSystem;
    
    EcsWorld ecsWorld;
    GameData gameData;
    public void Init()
    {
        fabricaSystem=new FabricaSystem();
           
        var playerData = ecsWorld.NewEntity();
       
        ref var playerdataComponent = ref playerData.Get<PlayerDataComponent>();
       
        GameObject levelPrefab = GetLevelPrefab(levelIndex: playerdataComponent.levelIndex, subLevelIndex: playerdataComponent.subLevelIndex);
        CreateLevel(levelPrefab);
    }
    GameObject GetLevelPrefab(int levelIndex,int subLevelIndex)
    {
        return gameData.levelsPrefabs.levels[levelIndex].subLevels[subLevelIndex];
    }
    void CreateLevel(GameObject levelPrefab)
    {
        fabricaSystem.CreateLevel(levelPrefab);
    }
}
