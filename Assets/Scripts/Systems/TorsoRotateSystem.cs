using Leopotam.Ecs;
using UnityEngine;

public class TorsoRotateSystem : IEcsRunSystem
{
    private EcsFilter<PlayerComponent> filter;
  
    public void Run()
    {
        
        foreach (var i in filter)
        {
            ref var playerComponent = ref filter.Get1(i);

            RotateTorso(ref playerComponent);
        }

    }
    private void RotateTorso(ref PlayerComponent playerComponent)
    {
        if (playerComponent.target)
        {
            Debug.Log("Current player target = " + playerComponent.target.name);
            Vector3 dir = playerComponent.target.transform.position - playerComponent.playerTorsoTransform.position;

            Vector3 newDirection = Vector3.RotateTowards(playerComponent.playerTorsoTransform.forward, new Vector3(dir.x, 0, dir.z), playerComponent.torsoSpeedRotate * Time.deltaTime, 0.0f);
            playerComponent.playerTorsoTransform.rotation = Quaternion.LookRotation(newDirection);
           

        }
        else
        {
            Debug.Log("Current player target = null");
            Vector3 newDirection = Vector3.RotateTowards(playerComponent.playerTorsoTransform.forward, playerComponent.playerChassisTransform.forward, playerComponent.torsoSpeedRotate * Time.deltaTime, 0.0f);
            playerComponent.playerTorsoTransform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}
