using System.Collections;
using System.Collections.Generic;
using Parents;
using UnityEngine;

public class EnemyBattleController : BattleController
{
    //Те, что указываются в Editor'е
    public GameObject Player;
    // Start is called before the first frame update
    EnemyMovementController enemyMovementController;
    void Start()
    {
        enemyMovementController = GetComponent<EnemyMovementController>();
        SetHealth(MaxHealth);
    }

    void Update()
    {
        if(CurrentHealth <= 0)
        {
            Destroy(ThisObject);
        }
        
    }
  /*public void Strike()
    {
        if(Player != null)
        {
            PlayerBattleController battleController = Player.GetComponent<PlayerBattleController>();
            battleController.GetDamage(Damage);
        }
        else
        {
            enemyMovementController.currentSeacrchingState = Idle;
        }
    }*/
}