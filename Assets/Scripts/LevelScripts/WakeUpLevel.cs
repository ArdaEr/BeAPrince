using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WakeUpLevel : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<TimeLineBoo>().timeline = false;
            SceneManager.LoadScene("WakeUpScene");
            
        }       
    }
}