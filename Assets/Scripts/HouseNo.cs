using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class HouseNo : MonoBehaviour
{
    [SerializeField] PlayableDirector playable;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playable.enabled = true;
            playable.Play();
        }
    }
}
