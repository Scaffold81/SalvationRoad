using UnityEngine;
[System.Serializable]
public struct CameraComponent
{
    public Transform cameraTransform;
    
    public float cameraFollowSmoothness;
    
    public Vector3 cameraOffset;
    public Vector3 cameraCurrentVelocity;
}
