using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool IsFighting = true;
    public int Damage;
    public float JumpPower = 100;
    private bool FaceRight = true;
    public float RunningSpeed;
    float SpeedX = 0;
    public bool CanJump = true;
    public Rigidbody2D Rb;
    public double Health = 5;
    public GameObject Player;
    private Animator Anim;

    //Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();
    }

    void flip()
    {
        FaceRight = !FaceRight;
        Rb.transform.Rotate(0f, 180f, 0f);
    }

    public void Rigt()
    {
        Anim.SetBool("IsRunning", true);
        if (!FaceRight)
        {
            flip();
        }
        SpeedX = RunningSpeed;
    }

    public void Left()
    {
        Anim.SetBool("IsRunning", true);
        if (FaceRight)
        {
            flip();
        }

        SpeedX = -RunningSpeed;
    }
    public void Jump()
    {
        if (CanJump)
        {
            Rb.AddForce(Vector2.up * JumpPower);
            CanJump = false;
        }
    }
    public void Figth()
    {
        IsFighting = false;
        SpeedX = 0;
        Anim.SetBool("Fight", true);
    }

    public void StopFight()
    {
        IsFighting = true;
        Anim.SetBool("Fight", false);
    }

    public void Stop()
    {
        Anim.SetBool("IsRunning", false);
        SpeedX = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (SpeedX != 0 & CanJump & IsFighting)
        {
            Rb.MovePosition(Rb.position + Vector2.right * SpeedX * Time.deltaTime);
            Anim.SetBool("IsRunning", true);
        }
        if (Health <= 0)
        {
            Destroy(Player);
        }
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.gameObject.tag)
        {
            case "Ground":
                CanJump = true;
                break;
        }
    }
}