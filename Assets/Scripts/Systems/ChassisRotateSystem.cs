using Leopotam.Ecs;
using UnityEngine;

public class ChassisRotateSystem : IEcsRunSystem
{
    private EcsFilter<PlayerComponent> filter;

    private PlayerComponent playerComponent;
    public void Run()
    {
        foreach (var i in filter)
        {
            playerComponent = filter.Get1(i);
        }
        Vector3 newDirection = Vector3.RotateTowards(playerComponent.playerChassisTransform.forward,new Vector3(playerComponent.moveDirection.x,0, playerComponent.moveDirection.z) ,1*Time.deltaTime,0.0f);
        playerComponent.playerChassisTransform.rotation = Quaternion.LookRotation(newDirection);
    }

    
}
