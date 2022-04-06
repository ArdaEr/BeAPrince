using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LittleKidController : MonoBehaviour
{
    [SerializeField] float speed = 6f;
    Vector2 moveInput;
    Rigidbody2D _rigid;
    Animator _anim;
    CapsuleCollider2D _bodyCollider;
    SpriteRenderer _sprite;
    bool playerHasHorizontalSpeed = false;
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _bodyCollider = GetComponent<CapsuleCollider2D>();
        _anim = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();

    }
    void Update()
    {
        Run();
    }


    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

    }

    void Run()
    {
        Vector2 playerVelocity =
                new Vector2(moveInput.x * speed, moveInput.y * speed);
        _rigid.velocity = playerVelocity;

        if(Mathf.Abs(_rigid.velocity.x) > Mathf.Epsilon || Mathf.Abs(_rigid.velocity.y) > Mathf.Epsilon)
        {playerHasHorizontalSpeed = true;}
        //bool playerHasHorizontalSpeed = Mathf.Abs(_rigid.velocity.x) > Mathf.Epsilon;
        _anim.SetBool("isWalk", playerHasHorizontalSpeed);
    }

}