using System.Collections;
using System.Collections.Generic;
using System;
using Parents;
using UnityEngine;
using Unity.Mathematics;

public class EnemyMovementController : MovementController
{
    EnemyBattleController enemybattleController { get; set; }

    //Переменные из Unity Editor
    public GameObject Player;
    public float MinDistance;
    public float StrikeDistance;

    //Внутренние переменные
    Rigidbody2D PlayerRb;
    double distance;

    // Start is called before the first frame update
    void Start()
    {
        enemybattleController = GetComponent<EnemyBattleController>();

        rigidbody2d = GetComponent<Rigidbody2D>();
        PlayerRb = Player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
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
                enemybattleController.Strike(Player);
            }
        }
    }
    void RunToPlayer()
    {
        if (distance > 0)
        {
            RunLeft();
        }
        else
        {
            RunRight();
        }

        rigidbody2d.MovePosition(rigidbody2d.position + Vector2.right * SpeedX);
    }
}