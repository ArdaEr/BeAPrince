using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToVilLevel : MonoBehaviour
{
    private void OnEnable() 
    {
        SceneManager.LoadScene("WakeUpScene");
    }
}
