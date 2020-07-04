using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers.EntityControllers
{
    public class MeleeAttackZoneController : MonoBehaviour
    {
        BattleController BattleController { get; set; }

        // Start is called before the first frame update
        void Start()
        {
            BattleController = transform.parent.GetComponent<BattleController>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == BattleController.EnemyTag)
            {
                BattleController.AddTriggeredEnemy(collision.gameObject);
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == BattleController.EnemyTag)
            {
                BattleController.RemoveTriggeredEnemy(collision.gameObject);
            }
        }
    }
}