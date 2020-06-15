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
}