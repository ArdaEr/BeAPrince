using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KidDisable : MonoBehaviour
{
    public PlayerInput kid;
    void OnEnable()
    {
        kid.enabled = false;
    }
    private void OnDisable() {
        kid.enabled = true;
    }
}
