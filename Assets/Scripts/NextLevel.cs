using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] float LevelLoadDelay = 1f;
    [SerializeField] PlayableDirector isEnoughCoin;
    Animator _anim;
    private void Start() {
        _anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(FindObjectOfType<GameSessionFarmer>().score == 8 )
            {
                FindObjectOfType<GameSessionFarmer>().isFarmerQuest = true;
                _anim.SetBool("Open", true);
                StartCoroutine(LoadNextLevel());
            }
            else
            {
                isEnoughCoin.Play(); 
            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            
        }
    }
    IEnumerator LoadNextLevel()
    {  
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        SceneManager.LoadScene("WakeUpScene");
    }
}
