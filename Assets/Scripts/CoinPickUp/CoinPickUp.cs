using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    [SerializeField] AudioClip _audio;
    [SerializeField] int pointsForCoin = 1;
    bool wasCollected = false;
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            FindObjectOfType<GameSessionBlackSmith>().TakeCoin(pointsForCoin);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(_audio, Camera.main.transform.position);
        }
    }
}
