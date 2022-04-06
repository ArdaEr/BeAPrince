using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] float LevelLoadDelay = 1f;
    Animator _anim;
    private void Start() {
        _anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<GameSessionFarmer>().isFarmerQuest = true;
            _anim.SetBool("Open", true);
            StartCoroutine(LoadNextLevel());
        }
        
    }
    IEnumerator LoadNextLevel()
    {  
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        SceneManager.LoadScene("WakeUpScene");
    }
}
