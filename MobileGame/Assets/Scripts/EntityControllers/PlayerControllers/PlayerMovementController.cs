using System.Collections;
using System.Collections.Generic;
using Parents;
using UnityEngine;

public class PlayerMovementController : MovementController
{
    public override AnimationController animationController { get; set; }
    public override BattleController battleController { get; set; }
}