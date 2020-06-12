﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattleController : MonoBehaviour
{
    List<Collider2D> Colliders { get; set; }
    PlayerMovementController MovementController { get; set; }
    PlayerAnimationController AnimationController { get; set; }

    //Те, которые указываются в редакторе Unity
    public GameObject PlayerObject;

    public GameObject HealthBarLine;
    public GameObject HealthBarTip;

    private Image HealthBarLineImage;
    private RectTransform HealthBarRect;
    private RectTransform HealthBarTipRect;
    private float HealthBarMaxWidth;
    private float HealthBarTipDefaultX;

    float currentHealth;
    public float CurrentHealth => currentHealth;

    public float MaxHealth;
    public int Damage;
    public float HitDelay;
    public float StrikePeriod;

    public float testHealth;

    //Всякие boolean-ы
    public bool CanStrike { get; private set; }

    void Start()
    {
        Colliders = new List<Collider2D>();
        MovementController = GetComponent<PlayerMovementController>();
        AnimationController = GetComponent<PlayerAnimationController>();

        CanStrike = true;


        HealthBarLineImage = HealthBarLine.GetComponent<Image>();

        HealthBarRect = HealthBarLine.GetComponent<RectTransform>();
        HealthBarMaxWidth = HealthBarRect.rect.width;

        HealthBarTipRect = HealthBarTip.GetComponent<RectTransform>();
        HealthBarTipDefaultX = HealthBarTipRect.anchoredPosition.x;

        SetHealth(MaxHealth);
    }
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            Destroy(PlayerObject);
        }

        SetHealth(testHealth);
    }

    void SetHealth(float value)
    {
        currentHealth = value > MaxHealth ? MaxHealth : value;

        float healthPercent = currentHealth / MaxHealth;

        HealthBarLineImage.fillAmount = healthPercent;

        if (healthPercent > 0)
        {
            var tipPosX = healthPercent * HealthBarMaxWidth * 0.795522f;
            HealthBarTipRect.anchoredPosition = new Vector2(HealthBarTipDefaultX + tipPosX, HealthBarTipRect.anchoredPosition.y);
        }
        else
        {
            HealthBarTip.SetActive(false);
        }
    }
    public void GetDamage(float damageAmount)
    {
        SetHealth(CurrentHealth - damageAmount);
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
