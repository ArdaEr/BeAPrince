using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineBoo : MonoBehaviour
{
    
    [SerializeField] PlayableDirector director;
    public bool timeline = true;
    private void Start()
    {
        if (timeline)
        {
            director.Play();
        }
        else
        {
            director.Stop();
        }
    }
}
