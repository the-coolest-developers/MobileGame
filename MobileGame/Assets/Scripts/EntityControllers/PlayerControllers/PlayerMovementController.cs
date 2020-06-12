using System.Collections;
using System.Collections.Generic;
using Parents;
using UnityEngine;

public class PlayerMovementController : MovementController
{
    //Из Unity едитора
    public GameObject PlayerObject { get; set; }
    public bool IsOnTheGround { get; set; }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        AnimationController = GetComponent<PlayerAnimationController>();
        BattleController = GetComponent<PlayerBattleController>();

        FaceRight = true;
        IsOnTheGround = true;
    }
    void Update()
    {
        if (SpeedX != 0 & IsOnTheGround & BattleController.CanStrike)
        {
            rigidbody.MovePosition(rigidbody.position + Vector2.right * SpeedX /* Time.deltaTime*/);
            AnimationController.SetIsRunning();//make speed 0.25 for normal running speed
        }
    }

    public void StopRunning()
    {
        AnimationController.SetIsNotRunning();
        SpeedX = 0;
    }

    void Flip()
    {
        FaceRight = !FaceRight;
        rigidbody.transform.Rotate(0f, 180f, 0f);
    }
    public void RunRight()
    {
        AnimationController.SetIsRunning();
        if (!FaceRight)
        {
            Flip();
        }
        SpeedX = RunningSpeed;
    }
    public void RunLeft()
    {
        AnimationController.SetIsRunning();
        if (FaceRight)
        {
            Flip();
        }
        SpeedX = -RunningSpeed;
    }
    public void Jump()
    {
        if (IsOnTheGround)
        {
            rigidbody.AddForce(Vector2.up * JumpPower);
            IsOnTheGround = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                IsOnTheGround = true;
                break;
        }
    }
}
