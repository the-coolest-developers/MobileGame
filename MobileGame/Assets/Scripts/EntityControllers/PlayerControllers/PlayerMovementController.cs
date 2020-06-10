using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public GameObject PlayerObject { get; set; }
    Rigidbody2D PlayerRb { get; set; }

    PlayerAnimationController AnimationController { get; set; }
    PlayerBattleController BattleController { get; set; }


    public float JumpPower;
    public float RunningSpeed;

    private bool FaceRight { get; set; }
    public bool IsOnTheGround { get; set; }

    float SpeedX { get; set; } = 0;

    void Start()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
        AnimationController = GetComponent<PlayerAnimationController>();
        BattleController = GetComponent<PlayerBattleController>();

        FaceRight = true;
        IsOnTheGround = true;
    }
    void Update()
    {
        if (SpeedX != 0 & IsOnTheGround & BattleController.CanStrike)
        {
            PlayerRb.MovePosition(PlayerRb.position + Vector2.right * SpeedX /* Time.deltaTime*/);
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
        PlayerRb.transform.Rotate(0f, 180f, 0f);
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
            PlayerRb.AddForce(Vector2.up * JumpPower);
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
