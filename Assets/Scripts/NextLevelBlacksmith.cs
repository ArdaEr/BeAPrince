using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelBlacksmith : MonoBehaviour
{
    [SerializeField] float LevelLoadDelay = 0.5f;
    Animator _anim;
    private void Start() {

        _anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<GameSessionBlackSmith>().isBlacksmithQuest = true;
            StartCoroutine(LoadNextLevel());
        }
        
    }
    IEnumerator LoadNextLevel()
    {  
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        SceneManager.LoadScene("WakeUpScene");
    }
}
