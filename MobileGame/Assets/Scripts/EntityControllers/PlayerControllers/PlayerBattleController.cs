using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.UI_Controllers.PlayerControllers;
using EntityControllers;
using Assets.Scripts.UI_Controllers;

namespace EntityControllers.PlayerControllers
{
    public class PlayerBattleController : BattleController
    {
        //Те, которые указываются в редакторе Unity
        public GameObject HealthBarLine;
        public GameObject HealthBarTip;

        public override HealthBarController HealthBarController { get; protected set; }

        protected override void Start()
        {
            MovementController = GetComponent<PlayerMovementController>();
            AnimationController = GetComponent<PlayerAnimationController>();
            HealthBarController = GetComponent<PlayerHealthBarController>();

            base.Start();
        }

        void Update()
        {
        }
    }
}