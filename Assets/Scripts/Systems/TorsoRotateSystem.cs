using Leopotam.Ecs;
using UnityEngine;

public class TorsoRotateSystem : IEcsRunSystem
{
    private EcsFilter<PlayerComponent> filter;

   // private PlayerComponent playerComponent;
    public void Run()
    {
        foreach (var i in filter)
        {
        ref  var  playerComponent =ref filter.Get1(i);
         //   Debug.Log("Current Target" + playerComponent.target.position);
          /*  if (playerComponent.target)
            {
                Vector3 newDirection = Vector3.RotateTowards(playerComponent.playerTorsoTransform.forward, new Vector3(playerComponent.target.transform.position.x, 0, playerComponent.target.transform.position.z), 8 * Time.deltaTime, 0.0f);
                playerComponent.playerTorsoTransform.rotation = Quaternion.LookRotation(newDirection);
                Debug.Log("Current Target" + playerComponent.target);
            }*/
        }
       
    }
}
