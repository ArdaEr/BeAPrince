using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePersistFarmer : MonoBehaviour
{
    void Awake() 
    {
    int numScenePersists = FindObjectsOfType<ScenePersistFarmer>().Length;
    if(numScenePersists > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ScenePersistDeath()
    {
        Destroy(gameObject);
    }

}
