using Controllers.EntityControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Controllers.BehaviorControllers
{
    public class BehaviorController : MonoBehaviour
    {
        BattleController BattleController;
        AnimationController AnimationController;
        MovementController MovementController;

        protected void Start()
        {
            BattleController = GetComponent<BattleController>();
            AnimationController = GetComponent<AnimationController>();
            MovementController = GetComponent<MovementController>();
        }
    }
}
