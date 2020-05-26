using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private bool IsFighting = true;
	public int Damage;
	public float JumpPover= 100;
	private bool FaceRight = true;
    public float SpeedRun;
    float speedX = 0;
	public bool CanJump = true;
	public Rigidbody2D rb;
	public double health = 5;
	public GameObject player;
	private Animator anim;
	
	//Start is called before the first frame update
    void Start()
    {

		anim = 	GetComponent<Animator>();
        rb = GetComponent <Rigidbody2D>();
    }

	void flip()
	{
		FaceRight = !FaceRight;
		rb.transform.Rotate(0f, 180f, 0f);
	}
	
	public void Rigt()
    {	
		
		if(!FaceRight)
			flip();
		speedX = SpeedRun;
		
	}

    public void Left()
    {
		anim.SetBool("IsRunning", true);
		if(FaceRight)
			flip();
        
		speedX = -SpeedRun;
		
	}
	public void Jump()
	{
		if(CanJump)
		{
			rb.AddForce(Vector2.up*JumpPover);
			CanJump = false;
		}
	}
	public void Figth()
	{
		IsFighting = false;
		speedX = 0;
		anim.SetBool("Fight", true);
	}

	public void StopFight()
	{
		IsFighting = true;
		anim.SetBool("Fight", false);
	}

    public void Stop()
    {
		anim.SetBool("IsRunning", false);
        speedX = 0;
    }
    // Update is called once per frame
    void Update()
    {
		if(speedX != 0 & CanJump & IsFighting)
		{
			rb.MovePosition(rb.position + Vector2.right * speedX * Time.deltaTime);
			anim.SetBool("IsRunning", true);
		}
		if(health <= 0)
		{
			Destroy(player);
		}
	}


	void OnTriggerEnter2D(Collider2D collider)
	{	
		switch(collider.gameObject.tag)
		{
			case "Ground":
				CanJump = true;
			break;
		}
	}
}		