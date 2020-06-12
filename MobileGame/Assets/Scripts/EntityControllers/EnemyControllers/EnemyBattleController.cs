using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleController : MonoBehaviour
{
    //Те, что указываются в Editor'е
    GameObject Enemy;
    public float HP;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(Enemy);
        }
    }
    public void GetDamage(float damage)
    {
        HP -= damage;
    }
}
