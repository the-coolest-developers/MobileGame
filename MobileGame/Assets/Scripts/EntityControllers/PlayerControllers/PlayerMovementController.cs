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
        rigidbody2d = GetComponent<Rigidbody2D>();
        AnimationController = GetComponent<PlayerAnimationController>();
        battleController = GetComponent<PlayerBattleController>();

        FaceRight = true;
        IsOnTheGround = true;
    }
    void FixedUpdate()
    {
        if (SpeedX != 0 & IsOnTheGround & battleController.CanStrike)
        {
            rigidbody2d.MovePosition(rigidbody2d.position + Vector2.right * SpeedX);
            AnimationController.SetIsRunning();
        }
    }

    public void Jump()
    {
        if (IsOnTheGround)
        {
            rigidbody2d.AddForce(Vector2.up * JumpPower);
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
