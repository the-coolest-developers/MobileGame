using System.Collections;
using System.Collections.Generic;
using System;
using Parents;
using UnityEngine;

public class EnemyMovementController : MovementController
{
    //Переменные из Unity Editor
    public Rigidbody2D PlayerRB;
    public int MinDistance;
    public int StrikeMinimalDistance;
    //Внутренние переменные
    private bool SawThePlayer = false;
    double RoundedDistance;
    delegate void CurrentMovemingState();
    public delegate void CurrentSeacrchingState();
    CurrentMovemingState currentMovemingState;
    public CurrentSeacrchingState currentSeacrchingState;
    EnemyBattleController battleController { get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
        battleController = GetComponent<EnemyBattleController>();

        rigidbody2d = GetComponent<Rigidbody2D>();

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
        float FullDistance = rigidbody2d.transform.position.x - PlayerRB.transform.position.x;
        RoundedDistance = Math.Round(FullDistance);
        if(RoundedDistance > MinDistance | -RoundedDistance < MinDistance)
        {
            SawThePlayer = false;
            currentMovemingState = RunToPlayer;
        }
    }
    void RunToPlayer()
    {
        if(RoundedDistance > StrikeMinimalDistance)
        {
            RunLeft();
        }
        else if(RoundedDistance < -StrikeMinimalDistance)
        {
            RunRight();
        }
        else
        {
            //currentMovemingState = battleController.Strike;
        }
        
        rigidbody2d.MovePosition(rigidbody2d.position + Vector2.right * SpeedX);
    }
}
