using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class NextLevelBlacksmith : MonoBehaviour
{
    [SerializeField] float LevelLoadDelay = 0.5f;
    [SerializeField] PlayableDirector isEnoughCoin;
    Animator _anim;
    private void Start() 
    {
     _anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(FindObjectOfType<GameSessionBlackSmith>().score == 8 )
            {
                FindObjectOfType<GameSessionBlackSmith>().isBlacksmithQuest = true;
                _anim.SetBool("Open", true);
                StartCoroutine(LoadNextLevel());
            }
        else
            {
                isEnoughCoin.Play(); 
            }
    }
    IEnumerator LoadNextLevel()
    {  
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        SceneManager.LoadScene("WakeUpScene");
    }
}