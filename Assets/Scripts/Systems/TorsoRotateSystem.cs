using Leopotam.Ecs;
using UnityEngine;

public class TorsoRotateSystem : IEcsRunSystem
{
    private EcsFilter<PlayerComponent> filter;

    private PlayerComponent playerComponent;
    public void Run()
    {
        Vector3 newDirection;
        foreach (var i in filter)
        {
            playerComponent = filter.Get1(i);


        }
        if (playerComponent.target != null)
        {
            newDirection = Vector3.RotateTowards(playerComponent.playerTorsoTransform.forward, new Vector3(playerComponent.target.transform.position.x, 0, playerComponent.target.transform.position.z), playerComponent.torsoSpeedRotate * Time.deltaTime, 0.0f);
        }
        else
        {
            newDirection= Vector3.RotateTowards(playerComponent.playerTorsoTransform.forward, new Vector3(playerComponent.playerChassisTransform.transform.position.x, 0, playerComponent.playerChassisTransform.transform.position.z), playerComponent.torsoSpeedRotate * Time.deltaTime, 0.0f);
        }
        playerComponent.playerTorsoTransform.rotation = Quaternion.LookRotation(newDirection);
    }
}
