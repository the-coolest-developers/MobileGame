using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject SwordPoint;
    public Rigidbody2D PlayerRb;
    int steps = 5;
    int ind = 600;
    public float HP = 10;
    public float speed = 10f;
	private Rigidbody2D rb;
	public GameObject enemy;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.MovePosition(rb.position+Vector2.right*steps*Time.deltaTime);
        ind--;
        if(ind == 0)
        {
            ind = 600;
            steps = -steps;
        }

        if(HP<=0)
        {
            Destroy(enemy);
        }
        
    }
    public void Damage()
    {
        float distance = Vector2.Distance(rb.position, SwordPoint.transform.position);
        if(distance < 1)
        {
            HP -= 5;
        }
    }  
}
