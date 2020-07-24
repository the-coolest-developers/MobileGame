using Controllers.EntityControllers;
using Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Scripts.Models;

namespace Controllers.EntityControllers
{
    public class AttributeController : MonoBehaviour
    {
        //Основные переменные
        public EntityAttribute JumpPower;
        public EntityAttribute RunningSpeed;

        public EntityAttribute Damage;
        public EntityAttribute StrikePeriod;

        public EntityAttribute Health;
        public EntityAttribute MaxHealth;
    }
} 