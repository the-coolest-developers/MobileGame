﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Parents;

public class PlayerBattleController :  BattleController
{
    List<Collider2D> Colliders { get; set; }
    

    //Те, которые указываются в редакторе Unity
    
    public GameObject HealthBarLine;
    public GameObject HealthBarTip;
    public float testHealth;

    //Внутренние переменные
    private Image HealthBarLineImage;
    private RectTransform HealthBarRect;
    private RectTransform HealthBarTipRect;
    private float HealthBarMaxWidth;
    private float HealthBarTipDefaultX;
    

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
        HealthBarLineChanging();
    }
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            Destroy(ThisObject);
        }

        SetHealth(testHealth);
        HealthBarLineChanging();
    }

    
    
    void HealthBarLineChanging()
    {
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
            var controllerScript = enemyCollider.gameObject.GetComponent<EnemyBattleController>();
            controllerScript.GetDamage(Damage);
        }
    }
    IEnumerator StrikePeriodCoroutine()
    {
        CanStrike = false;

        yield return new WaitForSeconds(StrikePeriod);

        CanStrike = true;
    }

    protected void OnTriggerEnter2D(Collider2D collision) => Colliders.Add(collision);
    protected void OnTriggerExit2D(Collider2D collision) => Colliders.Remove(collision);
}
