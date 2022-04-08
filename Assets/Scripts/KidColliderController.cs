using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.InputSystem;

public class KidColliderController : MonoBehaviour
{
    public PlayableDirector director1;
    public PlayableDirector director2;
    public PlayableDirector director3;
    public PlayableDirector director4;
    public PlayableDirector director5;
    public PlayableDirector director6;
    public PlayableDirector director7;

    public GameObject controlPanel;
    public PlayerInput playerInput;
    public SpriteRenderer render;

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Farmer" && FindObjectOfType<GameSessionFarmer>().isFarmerQuest == false)
        {
            StartCoroutine(DisableInput8());
            director4.Play();
        }
        else if(c.gameObject.tag == "Farmer" && FindObjectOfType<GameSessionFarmer>().isFarmerQuest == true)
        {
            StartCoroutine(DisableInput3());
            director5.Play();
        }
        if (c.gameObject.tag == "Blacksmith" && FindObjectOfType<GameSessionBlackSmith>().isBlacksmithQuest == false)
        {
            StartCoroutine(DisableInput8());
            director6.Play();
        }
        else if(c.gameObject.tag == "Blacksmith" && FindObjectOfType<GameSessionBlackSmith>().isBlacksmithQuest == true)
        {
            StartCoroutine(DisableInput8());
            director3.Play();
        }
        if (c.gameObject.tag == "Kingdom" && FindObjectOfType<GameSessionFarmer>().isFarmerQuest == false || FindObjectOfType<GameSessionBlackSmith>().isBlacksmithQuest == false )
        {
            StartCoroutine(DisableInput2());
            director7.Play();
        }
        else if(c.gameObject.tag == "Kingdom" && FindObjectOfType<GameSessionFarmer>().isFarmerQuest == true && FindObjectOfType<GameSessionBlackSmith>().isBlacksmithQuest == true )
        {
            StartCoroutine(DisableInput1());
            director2.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.tag == "Farmer")
        {
            director4.enabled = false;
        }
        if (c.gameObject.tag == "Blacksmith")
        {
            director6.enabled = false;
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
    IEnumerator DisableInput8()
    {
        playerInput.enabled = false;
        yield return new WaitForSecondsRealtime(8);
        playerInput.enabled = true;
    }
    IEnumerator DisableInput15()
    {
        playerInput.enabled = false;
        yield return new WaitForSecondsRealtime(15);
        playerInput.enabled = true;
    }


















}
