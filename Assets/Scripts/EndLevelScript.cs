using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class EndLevelScript : MonoBehaviour
{
    [SerializeField] float LevelLoadDelay = 0.5F;
    [SerializeField] PlayableDirector isEnoughCoin;
    Animator _anim;
    private void Start() {
        _anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(FindObjectOfType<GameSession>().score >= 15 )
            {
                _anim.SetBool("Open", true);
                StartCoroutine(LoadNextLevel());
            }
            else
            {
                isEnoughCoin.Play(); 
            }
        }
        
    }
    IEnumerator LoadNextLevel()
    {  
        
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        FindObjectOfType<ScenePersist>().ScenePersistDeath();
        SceneManager.LoadScene("FinalScene");
        
    }
}
