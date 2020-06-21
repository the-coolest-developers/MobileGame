using Assets.Scripts.UI_Controllers;
using EntityControllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntityControllers.EnemyControllers
{
    public class EnemyBattleController : BattleController
    {
        //Те, что указываются в Editor'е
        public GameObject Player;

        public override HealthBarController HealthBarController { get; protected set; }

        protected override void Start()
        {
            base.Start();

            MovementController = GetComponent<EnemyMovementController>();
            //AnimationController = GetComponent<EnemyAnimationController>();

            SetHealth(MaxHealth);
        }
    }
}