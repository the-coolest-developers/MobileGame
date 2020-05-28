using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Те, которые указываются в редакторе Unity
    public Rigidbody2D PlayerRb;
    public GameObject Enemy;
    public float HP;
    public float Speed;

    private Rigidbody2D Rb;

    //int Steps = 5;
    //int Ind = 600;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*Rb.MovePosition(Rb.position + Vector2.right * Steps * Time.deltaTime);
        Ind--;
        if (Ind == 0)
        {
            Ind = 600;
            Steps = -Steps;
        }*/

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
