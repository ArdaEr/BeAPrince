using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObject : MonoBehaviour
{
    [SerializeField] GameObject fa;

    private void OnEnable()
    {
        //gameobject.GetComponent<BoxCollider2D>().enabled = false;
        fa.tag = "GameController";
        //Destroy(playable);
    }
}
