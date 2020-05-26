using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public bool CanJump;
    private bool FaceRight = true;
    public float SpeedRun;
    float speedX;
    public Rigidbody2D rb;
    public void Rigt()
    {
        if(!FaceRight)
            flip();
        speedX = SpeedRun;
    }

    public void Left()
    {
        if(FaceRight)
            flip();
        speedX = -SpeedRun;
    }

    public void Stop()
    {
        speedX = 0;
    }

    void Update()
    {
        rb.MovePosition(rb.position + Vector2.right * speedX * Time.deltaTime);
    }
    void flip()
	{
		FaceRight = !FaceRight;
		transform.Rotate(0f, 180f, 0f);
	}

    void OnTriggerEnter2D(Collider2D collider)
	{	
		switch(collider.gameObject.name)
		{
			case "Ground":
				CanJump = true;
                Debug.Log("lol");
			break;
		}
	}

}
