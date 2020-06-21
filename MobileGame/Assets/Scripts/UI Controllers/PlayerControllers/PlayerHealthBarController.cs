using EntityControllers;
using EntityControllers.PlayerControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.UI_Controllers.PlayerControllers
{
    public class PlayerHealthBarController : HealthBarController
    {
        public override BattleController EntityBattleController { get; protected set; }

        protected override void Start()
        {
            EntityBattleController = GetComponent<PlayerBattleController>();

            base.Start();
        }
    }
}
