using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BotCamponentPrefabs", menuName = "CostomScriptableObjects/BotCamponentPrefabsSO")]
public class BotCamponentPrefabsSO : ScriptableObject
{
    public GameObject[] chassis;
    public GameObject[] torso;
    public GameObject[] primaryWeapon;
    public GameObject[] secondaryWeapon;
}
