using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraConfig", menuName ="CostomScriptableObjects/CameraConfigSO")]
public class CameraConfigSO : ScriptableObject
{
    public float cameraFollowSmoothness;
    public Vector3 cameraOffset;
}
