using System.Collections;
using System.Collections.Generic;
using Parents;
using UnityEngine;

public class EnemyBattleController : BattleController
{
    //Те, что указываются в Editor'е
    public GameObject Player;

    protected override void Start()
    {
        base.Start();

        MovementController = GetComponent<EnemyMovementController>();
        //AnimationController = GetComponent<EnemyAnimationController>();

        SetHealth(MaxHealth);
    }
}