using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSessionBlackSmith : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    public int score = 0;
    PlayerController _player;
    [SerializeField] TextMeshProUGUI _scoreT;
    public bool isBlacksmithQuest = false;

    void Awake() 
    {
        int numGameSessions = FindObjectsOfType<GameSessionBlackSmith>().Length;
        if(numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start() {
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
        FindObjectOfType<ScenePersist>().ScenePersistDeath();
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
