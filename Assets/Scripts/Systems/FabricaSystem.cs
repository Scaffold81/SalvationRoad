using Leopotam.Ecs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricaSystem 
{
	private EcsWorld ecsWorld;

    public FabricaSystem(EcsWorld world)
    {
        ecsWorld = world;
    }
    public void CreateLevel(GameObject levelPrefab)
    {
        MonoBehaviour.Instantiate(levelPrefab, Vector3.zero, Quaternion.identity);
        MonoBehaviour.print(message: "Level: " + " subLevel: " + "Created");
    }
    public void CreatePlayer(GameObject chassisPrefab, GameObject torsoPrefab, Vector3 spawnPointPosition)
    {
        
        

        var player_go = new GameObject();

        player_go.transform.position = spawnPointPosition;
        GameObject  chassisPrefab_t=MonoBehaviour.Instantiate<GameObject>(chassisPrefab, player_go.transform.position, Quaternion.identity);
        chassisPrefab_t.transform.SetParent(player_go.transform);

        EcsEntity playerEntity = ecsWorld.NewEntity();

        ref var player = ref playerEntity.Get<PlayerComponent>();
        
        player.playerTransform = player_go.transform;
    }
}
