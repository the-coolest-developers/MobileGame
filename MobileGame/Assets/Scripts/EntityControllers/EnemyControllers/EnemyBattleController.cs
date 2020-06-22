using Assets.Scripts.UI_Controllers;
using EntityControllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntityControllers.EnemyControllers
{
    public class EnemyBattleController : BattleController
    {
        protected override void FixedUpdate()
        {
            if (TriggeredEnemies.Count > 0)
            {
                Strike();
            }
        }
    }
}