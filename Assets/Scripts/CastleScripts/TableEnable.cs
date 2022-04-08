using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class TableEnable : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject table;

    private void OnEnable()
    {
        anim.gameObject.active = false;
        //table.GetComponent<BoxCollider2D>().enabled = false;
        table.tag = "GameController";
        //Destroy(playable);
    }
}
