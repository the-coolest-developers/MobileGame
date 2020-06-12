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
    CurrentMovemingState current;
    
    // Start is called before the first frame update
    
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        current = SearchThePlayer;
    }

    // Update is called once per frame
    
    void FixedUpdate()
    {
        float FullDistance = rigidbody2d.transform.position.x - PlayerRB.transform.position.x;
        RoundedDistance = Math.Round(FullDistance);
        current();
    }
    
    void SearchThePlayer()
    {
        if(RoundedDistance < MinDistance | -RoundedDistance > MinDistance)
        {
            SawThePlayer = false;
            current = RunToPlayer;
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
        
        rigidbody2d.MovePosition(rigidbody2d.position + Vector2.right * SpeedX);
    }
}
