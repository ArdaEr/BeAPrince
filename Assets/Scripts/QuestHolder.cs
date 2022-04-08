using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestHolder : MonoBehaviour
{
    GameSessionBlackSmith isBSQ;
    public bool isBS = false;
    void Awake() 
    {
        int numHoldersBS = FindObjectsOfType<QuestHolder>().Length;
        if(numHoldersBS > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start() {

        isBSQ = GetComponent<GameSessionBlackSmith>();
    
    }
}
