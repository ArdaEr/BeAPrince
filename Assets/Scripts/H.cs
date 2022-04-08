using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H : MonoBehaviour
{
    GameSessionFarmer isFQ;
    public bool isFQO = false;
    void Awake() 
    {
        int numHoldersF = FindObjectsOfType<H>().Length;
        if(numHoldersF > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start() {

        isFQ = GetComponent<GameSessionFarmer>();

    }
}
