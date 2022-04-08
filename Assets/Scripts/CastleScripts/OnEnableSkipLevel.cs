using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnEnableSkipLevel : MonoBehaviour
{
    [SerializeField] float LevelLoadDelay = 1f;
    private void OnEnable()
    {
        StartCoroutine(LoadNextLevel());
    }
    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) { nextSceneIndex = 0; }
        //FindObjectOfType<ScenePersist>().ScenePersistDeath();
        SceneManager.LoadScene(nextSceneIndex);
    }
}
