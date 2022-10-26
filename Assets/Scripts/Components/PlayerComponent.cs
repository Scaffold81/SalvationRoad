using UnityEngine;

public struct PlayerComponent
{
    public float moveSpeed;
    public float health;

    public Transform playerTransform;
    public Transform playerChassisTransform;
    public CharacterController playerCharasterController;
    public Vector3 moveDirection;
    internal Transform playerTorsoTransform;
}
