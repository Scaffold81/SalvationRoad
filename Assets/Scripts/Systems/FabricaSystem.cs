using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricaSystem 
{
  public void CreateLevel(GameObject levelPrefab)
    {
        MonoBehaviour.Instantiate(levelPrefab, Vector3.zero, Quaternion.identity);
        MonoBehaviour.print(message: "Level: " + " subLevel: " + "Created");
    }
}
