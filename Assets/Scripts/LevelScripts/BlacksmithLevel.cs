using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlacksmithLevel : MonoBehaviour
{
    private void OnEnable() 
    {
        FindObjectOfType<GameSessionBlackSmith>().isDash = true;
        SceneManager.LoadScene("BlacksmithLevel");
    }
}
