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
    public void CreatePlayer(GameObject playerPrefab,GameObject chassisPrefab, GameObject torsoPrefab, Vector3 spawnPointPosition)
    {
        EcsEntity playerEntity = ecsWorld.NewEntity();
        ref var player = ref playerEntity.Get<PlayerComponent>();

        GameObject player_go = MonoBehaviour.Instantiate<GameObject>(playerPrefab, spawnPointPosition, Quaternion.identity); 
        GameObject  chassisPrefab_t=MonoBehaviour.Instantiate<GameObject>(chassisPrefab, player_go.transform.position, Quaternion.identity);

        chassisPrefab_t.transform.SetParent(player_go.transform);
        
        player.playerTransform = player_go.transform;
        player.playerCharasterController =player_go.GetComponent<CharacterController>();
    }
}
