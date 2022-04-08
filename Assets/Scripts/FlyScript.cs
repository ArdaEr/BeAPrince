using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyScript : MonoBehaviour
{
    [SerializeField] GameObject[] _wayP;
    int currentWayPIndex = 0;
    Rigidbody2D _rigid;

    [SerializeField] float _platformSpeed = 2f;
    private void Start() 
    {
        _rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(Vector2.Distance(_wayP[currentWayPIndex].transform.position, transform.position) < .1f)
        {
            currentWayPIndex++;
            if(currentWayPIndex >= _wayP.Length)
            {
                FlipSprite();
                currentWayPIndex = 0;
            }
        }
        
        transform.position = Vector2.MoveTowards(transform.position, _wayP[currentWayPIndex].transform.position, Time.deltaTime * _platformSpeed);
    }
    void FlipSprite()
    {
            transform.localScale = 
            new Vector2 (Mathf.Sign(_rigid.velocity.x), 1f);
    }
}
