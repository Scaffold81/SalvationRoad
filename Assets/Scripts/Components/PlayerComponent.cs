using System.Collections.Generic;
using UnityEngine;

public struct PlayerComponent
{
    public float moveSpeed;
    public float health;
    public float viewRadius;
    public int viewAngle;
    public float torsoSpeedRotate;

    public List<EnemyView> targets;
    public EnemyView target;

    public Transform playerTransform;
    public Transform playerChassisTransform;
    public Transform playerTorsoTransform;
    public CharacterController playerCharasterController;
    
    public Vector3 moveDirection;
   
   
}
