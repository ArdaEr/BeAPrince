using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameSessionFarmer : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;
    PlayerController _player;
    public bool isFarmerQuest = false;

    void Awake() 
    {
        int numGameSessions = FindObjectsOfType<GameSessionFarmer>().Length;
        if(numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ProcessPlayerDeath()
    {
        if(playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }
    public void TakeCoin(int pointsToAdd)
    {
        score += pointsToAdd;
    }
    void ResetGameSession()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //FindObjectOfType<ScenePersist>().ScenePersistDeath();
        SceneManager.LoadScene(currentSceneIndex);
        Destroy(gameObject);
    }

    void TakeLife()
    {
        playerLives--;
        score = 0;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
