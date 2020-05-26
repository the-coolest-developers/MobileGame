using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public bool CanJump;
    private bool FaceRight = true;
    public float SpeedRun;
    float SpeedX;
    public Rigidbody2D rb;
    public void Rigt()
    {
        if(!FaceRight)
        {
            flip();
        }
        SpeedX = SpeedRun;
    }

    public void Left()
    {
        if(FaceRight)
        {
            flip();
        }
        SpeedX = -SpeedRun;
    }

    public void Stop()
    {
        SpeedX = 0;
    }

    void Update()
    {
        rb.MovePosition(rb.position + Vector2.right * SpeedX * Time.deltaTime);
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
