using System.Collections;
using System.Collections.Generic;
using System;
using Parents;
using UnityEngine;

public class EnemyMovementController : MovementController
{
    //Переменные из Unity Editor
    public GameObject Player;
    public float MinDistance;
    public float StrikeDistance;

    //Внутренние переменные
    Rigidbody2D PlayerRb;
    double RoundedDistance;
    delegate void CurrentMovemingState();
    public delegate void CurrentSeacrchingState();
    CurrentMovemingState currentMovemingState;
    public CurrentSeacrchingState currentSeacrchingState;
    EnemyBattleController enemybattleController { get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
        enemybattleController = GetComponent<EnemyBattleController>();

        rigidbody2d = GetComponent<Rigidbody2D>();
        PlayerRb = Player.GetComponent<Rigidbody2D>();

        currentMovemingState = Idle;
        currentSeacrchingState = SearchThePlayer;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentSeacrchingState();
        currentMovemingState();
    }
    public void Idle(){}
    
    public void SearchThePlayer()
    {
        if(Player != null)
        {
            float FullDistance = rigidbody2d.transform.position.x - PlayerRb.transform.position.x;
            RoundedDistance = Math.Round(FullDistance);
            if(RoundedDistance >= MinDistance | -RoundedDistance <= MinDistance)
            {
                currentMovemingState = RunToPlayer;
            }
        }
        else
        {
            currentSeacrchingState = Idle;
            currentMovemingState = Idle;
            
        }
        
    }
    void RunToPlayer()
    {
        if(RoundedDistance >= StrikeDistance)
        {
            RunLeft();
        }
        else if(RoundedDistance <= -StrikeDistance)
        {
            RunRight();
        }
        else
        {
            enemybattleController.Strike(Player);
        }
        rigidbody2d.MovePosition(rigidbody2d.position + Vector2.right * SpeedX);
    }
}