using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GameData 
{
    public CameraConfigSO cameraConfig;
    
    public TouchJoysticConfigSO touchJoysticConfig;
    public BotCamponentPrefabsSO botComponentsPrefabs;

    public LevelsPrefabsSO levelsPrefabs;

    public GameObject playerSpawnPoint;
}
