using Assets.Scripts.UI_Controllers;
using EntityControllers;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace EntityControllers.EnemyControllers
{
    public class EnemyBattleController : BattleController
    {
        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            var movementController = (EnemyMovementController)MovementController;
            var playerDistance = math.abs(movementController.PlayerDistance);

            if (TriggeredEnemies.Count > 0 && playerDistance <= movementController.StrikeDistance)
            {
                Strike();
            }
        }
    }
}