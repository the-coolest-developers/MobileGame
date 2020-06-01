using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    List<Collider2D> Colliders;

    //Те, которые указываются в редакторе Unity
    public GameObject Player;
    public int Damage;
    public float JumpPower;
    public float RunningSpeed;
    public double Health;
    public float HitDelay;

    //Всякие boolean-ы
    private bool IsFighting = false;
    private bool FaceRight = true;
    public bool IsOnTheGround = true;

    //Остальное
    float SpeedX = 0;
    public Rigidbody2D Rb;
    private Animator Anim;

    //Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();
        Colliders = new List<Collider2D>();
    }

    void Flip()
    {
        FaceRight = !FaceRight;
        Rb.transform.Rotate(0f, 180f, 0f);
    }

    public void Right()
    {
        Anim.SetBool("IsRunning", true);
        if (!FaceRight)
        {
            Flip();
        }
        SpeedX = RunningSpeed;
    }

    public void Left()
    {
        Anim.SetBool("IsRunning", true);
        if (FaceRight)
        {
            Flip();
        }
        SpeedX = -RunningSpeed;
    }
    public void Jump()
    {
        if (IsOnTheGround)
        {
            Rb.AddForce(Vector2.up * JumpPower);
            IsOnTheGround = false;
        }
    }
    public void Strike()
    {
        IsFighting = true;
        SpeedX = 0;
        Anim.SetBool("Fight", true);

        StartCoroutine(HitEnemy());
    }
    IEnumerator HitEnemy()
    {
        yield return new WaitForSeconds(HitDelay);
        var enemyCollider = Colliders.FirstOrDefault(c => c.gameObject.tag == "Enemy");
        if (enemyCollider != null)
        {
            var controllerScript = enemyCollider.gameObject.GetComponent<EnemyController>();
            controllerScript.GetDamage(Damage);
        }
    }

    public void StopFight()
    {
        IsFighting = false;
        Anim.SetBool("Fight", false);
    }

    public void Stop()
    {
        Anim.SetBool("IsRunning", false);
        SpeedX = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (SpeedX != 0 & IsOnTheGround & !IsFighting)
        {
            Rb.MovePosition(Rb.position + Vector2.right * SpeedX * Time.deltaTime);
            Anim.SetBool("IsRunning", true);
        }
        if (Health <= 0)
        {
            Destroy(Player);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Colliders.Add(collision);
        switch (collision.gameObject.tag)
        {
            case "Ground":
                IsOnTheGround = true;
                break;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Colliders.Remove(collision);
    }
}