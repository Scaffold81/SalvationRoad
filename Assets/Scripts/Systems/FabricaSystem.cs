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
        GameObject chassisPrefab_t=MonoBehaviour.Instantiate<GameObject>(chassisPrefab, player_go.transform.position, Quaternion.identity);
        GameObject torsoPrefab_t = MonoBehaviour.Instantiate<GameObject>(torsoPrefab, player_go.transform.position, Quaternion.identity);

        chassisPrefab_t.transform.SetParent(player_go.transform);
        torsoPrefab_t.transform.SetParent(player_go.transform);
        
        var chassisView = chassisPrefab_t.GetComponent<ChassisView>();
        var torsoView = torsoPrefab_t.GetComponent<TorsoView>();

        chassisPrefab_t.transform.localPosition = chassisView.localPosition;
        torsoPrefab_t.transform.localPosition = torsoView.localPosition;

        player.health += torsoView.health;
        player.health += chassisView.health;

        player.moveSpeed = chassisView.Speed;

        player.playerTransform = player_go.transform;
        player.playerChassisTransform = chassisPrefab_t.transform;
        player.playerTorsoTransform = torsoPrefab_t.transform;

        player.playerCharasterController =player_go.GetComponent<CharacterController>();
    }
}
