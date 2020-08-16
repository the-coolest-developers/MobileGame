using UnityEngine;

namespace Controllers.EntityControllers
{
    public class MeleeAttackZoneController : MonoBehaviour
    {
        private BattleController BattleController { get; set; }

        private void Start()
        {
            BattleController = transform.parent.GetComponent<BattleController>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(BattleController.enemyTag))
            {
                BattleController.AddTriggeredEnemy(collision.gameObject);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag(BattleController.enemyTag))
            {
                BattleController.RemoveTriggeredEnemy(collision.gameObject);
            }
        }
    }
}