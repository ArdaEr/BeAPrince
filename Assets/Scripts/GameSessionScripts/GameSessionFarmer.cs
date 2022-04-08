using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class GameSessionFarmer : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] public Image[] hearts;
    [SerializeField] public Sprite fullheart;
    [SerializeField] TextMeshProUGUI _scoreT;

    PlayerController _player;

    public bool isFarmerQuest = false;
    public int score = 0;



    void Awake() 
    {
        int numGameSessions = FindObjectsOfType<GameSessionFarmer>().Length;
        if(numGameSessions > 1 )
        {
            Destroy(gameObject);
        }
        else 
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start() 
    {
        _scoreT.text = score.ToString();
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
        _scoreT.text = score.ToString();

    }
    void ResetGameSession()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        FindObjectOfType<ScenePersistFarmer>().ScenePersistDeath();
        SceneManager.LoadScene(currentSceneIndex);
        Destroy(gameObject);
    }

    void TakeLife()
    {
        playerLives--;
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerLives)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
