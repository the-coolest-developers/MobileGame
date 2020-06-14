using System.Collections;
using System.Collections.Generic;
using Parents;
using UnityEngine;

public class PlayerMovementController : MovementController
{
    public override AnimationController AnimationController { get; set; }
    public override BattleController battleController { get; set; }

    void Start()
    {
        AnimationController = GetComponent<PlayerAnimationController>();
        battleController = GetComponent<PlayerBattleController>();
    }
    void FixedUpdate()
    {
    }
}
