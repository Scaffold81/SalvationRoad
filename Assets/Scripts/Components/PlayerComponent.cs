using System.Collections.Generic;
using UnityEngine;

public struct PlayerComponent
{
    public float moveSpeed;
    public float health;

    public List<EnemyView> targets;

    public Transform playerTransform;
    public Transform playerChassisTransform;
    public CharacterController playerCharasterController;
    public Vector3 moveDirection;
    public Transform playerTorsoTransform;
    public float viewRadius;
    public int viewAngle;
    internal EnemyView target;
}
