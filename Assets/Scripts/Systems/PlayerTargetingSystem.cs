using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetingSystem : IEcsRunSystem
{
    private EcsFilter<PlayerComponent> filter;
    private PlayerComponent playerComponent;
    public void Run()
    {
        foreach (var f in filter)
        {
            ref var _playerComponent = ref filter.Get1(f);
            playerComponent = _playerComponent;
        }
        FindVisibleTargets();
    }
    void FindVisibleTargets()
    {
        playerComponent.targets=new List<EnemyView>();

        Collider[] targetsInViewRadius = Physics.OverlapSphere(playerComponent.playerChassisTransform.position, playerComponent.viewRadius);
       
        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - playerComponent.playerChassisTransform.position).normalized;
            float dstToTarget = Vector3.Distance(playerComponent.playerChassisTransform.position, target.position);

            if (Vector3.Angle(playerComponent.playerChassisTransform.forward, dirToTarget) < playerComponent.viewAngle / 2)
            {
                RaycastHit hit;
                if (Physics.Raycast(playerComponent.playerChassisTransform.position, dirToTarget, out hit, dstToTarget))
                {
                    
                    if (target.GetComponent<EnemyView>() != null)
                    {
                        Debug.DrawLine(playerComponent.playerChassisTransform.position, hit.transform.position, Color.red);
                        playerComponent.targets.Add(target.GetComponent<EnemyView>());
                    }
                    else
                    {
                        Debug.DrawLine(playerComponent.playerChassisTransform.position, hit.transform.position, Color.green);
                    }

                }
            }
        }



    }
}
