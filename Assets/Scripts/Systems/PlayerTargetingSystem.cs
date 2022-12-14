using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetingSystem : IEcsRunSystem
{
    private EcsFilter<PlayerComponent> filter;
  //  private PlayerComponent playerComponent;
    public void Run()
    {
        foreach (var f in filter)
        {
            ref var playerComponent = ref filter.Get1(f);
            FindVisibleTargets(ref playerComponent);
           // SortObjects(playerComponent);
            GetClosestTarget(ref playerComponent);

            if (playerComponent.target != null)
            {
                Debug.DrawLine(playerComponent.playerChassisTransform.position, playerComponent.target.transform.position, Color.red);
            }
        }
    }
    void FindVisibleTargets(ref PlayerComponent playerComponent)
    {
        playerComponent.targets = new List<EnemyView>();

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
                        if (hit.collider.GetComponent<EnemyView>() != null)
                        {
                            playerComponent.targets.Add(target.GetComponent<EnemyView>());
                        }
                    }
                }
            }
        
    }
  /*  void SortObjects(PlayerComponent playerComponent)
    {
        if (playerComponent.targets.Count > 1)
            {
                playerComponent.targets.Sort(delegate (EnemyView t1, EnemyView t2)
                {
                    return Vector3.Distance(t1.transform.position, playerComponent.playerChassisTransform.position).CompareTo(Vector3.Distance(
                        t2.transform.position, playerComponent.playerChassisTransform.position));
                });
            }
    }*/
    private void GetClosestTarget(ref PlayerComponent playerComponent)
    {
        if (playerComponent.targets.Count == 0)
        {
                playerComponent.target = null;
        }
        else
        {
                playerComponent.target = playerComponent.targets[0].transform;
        }
    }
}
