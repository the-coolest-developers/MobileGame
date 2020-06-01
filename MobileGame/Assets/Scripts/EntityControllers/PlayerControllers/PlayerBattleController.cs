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

    //Всякие boolean-ы
    public bool IsFighting { get; private set; }

    void Start()
    {
        Colliders = new List<Collider2D>();
        MovementController = GetComponent<PlayerMovementController>();
        AnimationController = GetComponent<PlayerAnimationController>();

        IsFighting = false;
    }
    void Update()
    {

    }

    public void Strike()
    {
        //Debug.Log(IsFighting);
        if (!IsFighting)
        {
            IsFighting = true;

            MovementController.StopRunning();
            //AnimationController.RunFullStrikeAnimation();
            AnimationController.SetIsStriking();

            StartCoroutine(HitEnemyCoroutine());
        }
    }
    IEnumerator HitEnemyCoroutine()
    {
        yield return new WaitForSeconds(HitDelay);
        AnimationController.SetIsNotStriking();
        Debug.Log("Strike!");

        var enemyCollider = Colliders.FirstOrDefault(c => c.gameObject.tag == "Enemy");
        if (enemyCollider != null)
        {
            var controllerScript = enemyCollider.gameObject.GetComponent<EnemyController>();
            controllerScript.GetDamage(Damage);
        }

        IsFighting = false;
    }

    void OnTriggerEnter2D(Collider2D collision) => Colliders.Add(collision);
    void OnTriggerExit2D(Collider2D collision) => Colliders.Remove(collision);
}
