using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject SwordPoint;
    public Rigidbody2D PlayerRb;
    int Steps = 5;
    int Ind = 600;
    public float HP = 10;
    public float Speed = 10f;
    private Rigidbody2D Rb;
    public GameObject Enemy;


    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.MovePosition(rb.position+Vector2.right*steps*Time.deltaTime);
        Ind--;
        if (Ind == 0)
        {
            Ind = 600;
            Steps = -Steps;
        }

        if (HP <= 0)
        {
            Destroy(Enemy);
        }

    }
    public void Damage()
    {
        float distance = Vector2.Distance(Rb.position, SwordPoint.transform.position);
        if (distance < 1)
        {
            HP -= 5;
        }
    }
}
