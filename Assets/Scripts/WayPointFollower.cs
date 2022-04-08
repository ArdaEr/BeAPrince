using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] _wayP;
    int currentWayPIndex = 0;

    [SerializeField] float _platformSpeed = 2f;
    void Update()
    {
        if(Vector2.Distance(_wayP[currentWayPIndex].transform.position, transform.position) < .1f)
        {
            currentWayPIndex++;
            if(currentWayPIndex >= _wayP.Length)
            {
                currentWayPIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, _wayP[currentWayPIndex].transform.position, Time.deltaTime * _platformSpeed);
    }
}
