using System.Collections.Generic;
using UnityEngine;

public struct PlayerComponent
{
    public float moveSpeed;
    public float health;
    public float viewRadius;
    public float viewAngle;
    public float torsoSpeedRotate;

    public List<EnemyView> targets;
    public Transform target;

    public Transform playerTransform;
    public Transform playerChassisTransform;
    public Transform playerTorsoTransform;
    public CharacterController playerCharasterController;
    
    public Vector3 moveDirection;
   
   
}
