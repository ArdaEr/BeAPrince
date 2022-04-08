using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidDisable : MonoBehaviour
{
    [SerializeField] GameObject kid;
    void OnEnable()
    {
        kid.SetActive(false);
    }
}
