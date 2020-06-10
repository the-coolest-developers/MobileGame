using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerBattleController : MonoBehaviour
{
    List<Collider2D> Colliders { get; set; }
    PlayerMovementController MovementController { get; set; }
    PlayerAnimationController AnimationController { get; set; }

    //Те, которые указываются в редакторе Unity
    public GameObject PlayerObject;
    public int Damage;
    public double Health;
    public float HitDelay;
    public float StrikePeriod;

    //Всякие boolean-ы
    public bool CanStrike { get; private set; }

    void Start()
    {
        Colliders = new List<Collider2D>();
        MovementController = GetComponent<PlayerMovementController>();
        AnimationController = GetComponent<PlayerAnimationController>();

        CanStrike = true;
    }
    void Update()
    {
        if (Health <= 0)
        {
            Destroy(PlayerObject);
        }
    }

    public void Strike()
    {
        if (CanStrike)
        {
            StartCoroutine(StrikePeriodCoroutine());

            MovementController.StopRunning();
            AnimationController.PlayStrikeAnimation();

            StartCoroutine(HitEnemyCoroutine());
        }
    }
    IEnumerator HitEnemyCoroutine()
    {
        yield return new WaitForSeconds(HitDelay);
        var enemyCollider = Colliders.FirstOrDefault(c => c.gameObject.tag == "Enemy");
        if (enemyCollider != null)
        {
            var controllerScript = enemyCollider.gameObject.GetComponent<EnemyController>();
            controllerScript.GetDamage(Damage);
        }
    }
    IEnumerator StrikePeriodCoroutine()
    {
        CanStrike = false;

        yield return new WaitForSeconds(StrikePeriod);

        CanStrike = true;
    }

    void OnTriggerEnter2D(Collider2D collision) => Colliders.Add(collision);
    void OnTriggerExit2D(Collider2D collision) => Colliders.Remove(collision);
}
