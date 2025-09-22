using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movement, jump;
    [SerializeField] private float minX, maxX;

    private float x_axis;
    private float y_axis;
    private Vector3 pos;

    private bool isGrounded = true;

    private Rigidbody2D body;
    private SpriteRenderer sr;

    private Animator anim;
    private string Walk_Animation = "Walk";
    private string Ground_Tag = "Ground";
    private string Enemy_Tag = "Enemy";

    public static event Action OnPlayerHit;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        PLayer_Movement();
        Animation();
        Jump();
    }

    void LateUpdate()
    {
        pos = transform.position;

        if (pos.x < minX)
            pos.x = minX;
        else if (pos.x > maxX)
            pos.x = maxX;

        transform.position = pos;
    }

    void PLayer_Movement()
    {
        x_axis = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(x_axis, 0, 0) * Time.deltaTime * movement;
    }

    void Animation()
    {
        if(x_axis != 0)
        {
            anim.SetBool(Walk_Animation, true);
            if(x_axis > 0)
                sr.flipX = false; 
            else
                sr.flipX = true;
        }
        else
            anim.SetBool(Walk_Animation, false);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            body.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Ground_Tag))
            isGrounded = true;

        if (collision.gameObject.CompareTag(Enemy_Tag))
        {
            gameObject.SetActive(false);
            OnPlayerHit?.Invoke();
        }
    }
}
