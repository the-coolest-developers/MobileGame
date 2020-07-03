using Controllers.EntityControllers;
using Controllers.EntityControllers.PlayerControllers;

namespace Controllers.UI_Controllers.PlayerControllers
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
