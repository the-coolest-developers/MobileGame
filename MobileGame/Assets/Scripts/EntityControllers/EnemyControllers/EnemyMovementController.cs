using System.Collections;
using System.Collections.Generic;
using System;
using Parents;
using UnityEngine;
using Unity.Mathematics;

public class EnemyMovementController : MovementController
{
    public override BattleController battleController { get; set; }
    public override AnimationController animationController { get; set; }
 
    //Переменные из Unity Editor
    
    public float MinDistance;
    public float StrikeDistance;
    
    //Внутренние переменные
    double distance;
 
    // Update is called once per frame
    new void FixedUpdate()
    {
        if (Player != null)
        {
            distance = rigidbody2d.transform.position.x - PlayerRb.transform.position.x;
            var absoluteDistance = math.abs(distance);
 
            if (absoluteDistance <= MinDistance)
            {
                RunToPlayer();
            }
            if (absoluteDistance <= StrikeDistance)
            {
                battleController.Strike(Player);
            }
        }
    }
    void RunToPlayer()
    {
        if (distance > 0)
        {
            TurnLeft();
        }
        else
        {
            TurnRight();
        }

        rigidbody2d.MovePosition(rigidbody2d.position + Vector2.right * SpeedX);
    }
}