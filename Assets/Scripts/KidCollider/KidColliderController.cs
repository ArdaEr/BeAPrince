using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.InputSystem;

public class KidColliderController : MonoBehaviour
{
    
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
        if (c.gameObject.tag == "Farmer" && FindObjectOfType<H>().isFQO == false)
        {
            StartCoroutine(DisableInput18());
            director2.Play();
        }
        else if(c.gameObject.tag == "Farmer" && FindObjectOfType<H>().isFQO == true)
        {
            StartCoroutine(DisableInput3());
            director3.Play();
        }
        if (c.gameObject.tag == "Blacksmith" && FindObjectOfType<QuestHolder>().isBS == false)
        {
            StartCoroutine(DisableInput17());
            director4.Play();
        }
        else if(c.gameObject.tag == "Blacksmith" && FindObjectOfType<QuestHolder>().isBS == true)
        {
            StartCoroutine(DisableInput3());
            director5.Play();
        }
        if(c.gameObject.tag == "Kingdom")
        {
            if(FindObjectOfType<QuestHolder>().isBS == false || FindObjectOfType<H>().isFQO == false)
        {
            StartCoroutine(DisableInput5());
            director6.Play();
        }
            else if(FindObjectOfType<QuestHolder>().isBS == true && FindObjectOfType<H>().isFQO == true)
            {
            StartCoroutine(DisableInput1());
            director7.Play();
            }
        }

    }
    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.tag == "Farmer")
        {
            director2.enabled = false;
        }
        if (c.gameObject.tag == "Blacksmith")
        {
            director4.enabled = false;
        }
        if(c.gameObject.tag == "Kingdom")
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
        IEnumerator DisableInput5()
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
        yield return new WaitForSecondsRealtime(15);
        playerInput.enabled = true;
    }
    IEnumerator DisableInput17()
    {
        playerInput.enabled = false;
        yield return new WaitForSecondsRealtime(17);
        playerInput.enabled = true;
    }
    IEnumerator DisableInput18()
    {
        playerInput.enabled = false;
        yield return new WaitForSecondsRealtime(18);
        playerInput.enabled = true;
    }

















}
