using System.Collections;
using System.Collections.Generic;
using EntityControllers;
using Parents;
using UnityEngine;

public class PlayerMovementController : MovementController
{
    public override AnimationController AnimationController { get; set; }
    public override BattleController battleController { get; set; }
}