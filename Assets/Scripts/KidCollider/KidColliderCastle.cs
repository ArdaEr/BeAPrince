using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.InputSystem;

public class KidColliderCastle : MonoBehaviour
{
    public PlayableDirector director8;
    public PlayableDirector director9;
    public PlayableDirector director10;

    public GameObject controlPanel;
    public PlayerInput playerInput;
    
    private void OnTriggerEnter2D(Collider2D c) 
    {
        if(c.gameObject.tag == "Painting")
        {
            StartCoroutine(DisableInput3());
            director8.Play();
        }
        if(c.gameObject.tag == "King")
        {
            StartCoroutine(DisableInput15());
            director9.Play();
        }
        if(c.gameObject.tag == "Table")
        { 
            StartCoroutine(DisableInput4());
            director10.Play();
        }
    }


    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.tag == "Painting")
        {
            director8.enabled = false;
        }
        if (c.gameObject.tag == "King")
        {
            director9.enabled = false;
        }
        if (c.gameObject.tag == "Table")
        {
            director10.enabled = false;
        }
    }

    IEnumerator DisableInput1()
    {
        playerInput.enabled = false;
        yield return new WaitForSecondsRealtime(1);
        playerInput.enabled = true;

    }
    IEnumerator DisableInput2()
    {
        playerInput.enabled = false;
        yield return new WaitForSecondsRealtime(2);
        playerInput.enabled = true;

    }
    IEnumerator DisableInput3()
    {
        playerInput.enabled = false;
        yield return new WaitForSecondsRealtime(3);
        playerInput.enabled = true;

    }
        IEnumerator DisableInput4()
    {
        playerInput.enabled = false;
        yield return new WaitForSecondsRealtime(4);
        playerInput.enabled = true;

    }
    IEnumerator DisableInput8()
    {
        playerInput.enabled = false;
        yield return new WaitForSecondsRealtime(8);
        playerInput.enabled = true;
    }
    IEnumerator DisableInput15()
    {
        playerInput.enabled = false;
        yield return new WaitForSecondsRealtime(17);
        playerInput.enabled = true;
    }
}
