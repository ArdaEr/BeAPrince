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
         SceneManager.LoadScene("LastPlatform");

    }
}
