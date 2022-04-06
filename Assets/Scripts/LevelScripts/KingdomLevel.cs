using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KingdomLevel : MonoBehaviour
{
    private void OnEnable() 
    {
        SceneManager.LoadScene(0);
    }
}
