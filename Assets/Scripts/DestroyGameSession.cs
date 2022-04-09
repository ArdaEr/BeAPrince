using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameSession : MonoBehaviour
{
    private void Start() {
        Destroy(GameObject.Find("GameSessionFarmer"));
        Destroy(GameObject.Find("GameSessionBlacksmith"));
        Destroy(GameObject.Find("GameSession"));
    }
}
