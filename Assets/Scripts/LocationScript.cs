using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationScript : MonoBehaviour
{
    bool isleft;
    [SerializeField] Rigidbody2D playerposition;
    // Start is called before the first frame update
    void Start()
    {
        playerposition = GetComponent<Rigidbody2D>();
        if (isleft)
        {
            this.gameObject.transform.position = new Vector2(-7.15f, -1.9f);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LeftWay")
        {
            isleft = true;
        }
        else
        {
            isleft = false;
        }
    }
}
