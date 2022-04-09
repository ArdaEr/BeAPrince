using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 6f;
    [SerializeField] float jumpSpeed = 8f;
    [SerializeField] float secondJump = 2f;
    [SerializeField] float deathJump = 11f;
    [SerializeField] float deathTiming = 0.4f;
    [SerializeField] float dashPower = 20f;
    [SerializeField] float dashingTime = 0.5f;
    [SerializeField] float dashingCoolDown = 1f;
    [SerializeField] ParticleSystem _deathEffect;
    [SerializeField] ParticleSystem _jumpEffect;
    [SerializeField] TrailRenderer _tr;
    [SerializeField] AudioClip audio;

    Vector2 moveInput;
    Rigidbody2D _rigid;
    Animator _anim;
    CapsuleCollider2D _bodyCollider;
    SpriteRenderer _sprite;
    BoxCollider2D _feetCollider;
    GameSessionFarmer _session;

    bool canDash = true;
    bool isDashing;
    int jumpCounter = 0;
    bool isAlive = true;
    float gravityScaleAtStart;




    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _bodyCollider = GetComponent<CapsuleCollider2D>();
        _feetCollider = GetComponent<BoxCollider2D>();
        _sprite = GetComponent<SpriteRenderer>();
        
        gravityScaleAtStart = _rigid.gravityScale;

    }
    void Update()
    {
        if(!isAlive){return;}
        if(isDashing){return;}
        Run();
        Die();
        FlipSprite();
        
    }

    void OnMove(InputValue value)
    {
        if(!isAlive){return;}
        moveInput = value.Get<Vector2>();
        
    }
    void OnJump(InputValue value)
    {
        if(!isAlive){return;}
        if(value.isPressed && jumpCounter == 0 && _feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            _rigid.velocity += new Vector2 (0f, jumpSpeed );
            jumpCounter++;
        }
        else if(value.isPressed && jumpCounter == 1 && _feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
           _rigid.velocity += new Vector2 (0f, jumpSpeed );
        }
        else if(value.isPressed && jumpCounter == 1 )
        {
            _rigid.velocity += new Vector2 (0f, secondJump );
            JumpEffect();
            jumpCounter = 0;
        }
    }
    void OnDash(InputValue value)
    {   
        if(!isAlive){return;}
        if(value.isPressed && canDash)
        {
            StartCoroutine(Dash());
        }

    }
    void Run()
    {
        Vector2 playerVelocity = 
                new Vector2 (moveInput.x * speed,  _rigid.velocity.y);
        _rigid.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(_rigid.velocity.x) > Mathf.Epsilon;
        _anim.SetBool("isRun", playerHasHorizontalSpeed);
    }
    
    void FlipSprite()
    {
    bool playerHasHorizontalSpeed = Mathf.Abs(_rigid.velocity.x) > Mathf.Epsilon; // Epsilon teknikli 0 demek, X i miz ekside artıda olsa x değeri var sayılacak

    if(playerHasHorizontalSpeed)
        {
        transform.localScale = 
                new Vector2 (Mathf.Sign(_rigid.velocity.x), 1f);
        }
    }

    void Die()
    {
        if(_bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards", "Water")) || _feetCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards", "Water"))  )
        {
            isAlive = false;
            _rigid.velocity += new Vector2(_rigid.velocity.x, deathJump);
            //GetComponent<PlayerInput>().enabled = false;
            AudioSource.PlayClipAtPoint(audio, Camera.main.transform.position);
            _sprite.color = new Color (255, 0 , 0 , 255);
            Invoke("DeathEffect", deathTiming);
            _anim.SetTrigger("isDead");
            FindObjectOfType<GameSession>().Invoke("ProcessPlayerDeath", 1f);
            //AudioSource.PlayClipAtPoint(_audio, Camera.main.transform.position);
        }
    }

    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        _rigid.gravityScale = 0;
        _rigid.velocity = new Vector2(transform.localScale.x * dashPower, 0f);
        _tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        _tr.emitting = false;
        _rigid.gravityScale = gravityScaleAtStart;
        isDashing = false;
        yield return new WaitForSeconds(dashingCoolDown);
        canDash = true;

        
    }

    
    void DeathEffect()
    {
    _deathEffect.Play();
    }
    void JumpEffect()
    {
    _jumpEffect.Play();
    }



}

