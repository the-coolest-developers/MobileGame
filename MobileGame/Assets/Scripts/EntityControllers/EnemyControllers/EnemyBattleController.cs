using System.Collections;
using System.Collections.Generic;
using Parents;
using UnityEngine;

public class EnemyBattleController : BattleController
{
    //Те, что указываются в Editor'е
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
        SetHealth(MaxHealth);
    }

    void Update()
    {
        if(CurrentHealth <= 0)
        {
            Destroy(ThisObject);
        }
    }
}