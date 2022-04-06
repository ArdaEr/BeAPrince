using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FarmerLevel : MonoBehaviour
{
    private void OnEnable() 
    {
        SceneManager.LoadScene("FarmerLevel");
    }
}
