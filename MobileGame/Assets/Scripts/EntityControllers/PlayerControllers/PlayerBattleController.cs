﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Parents;

public class PlayerBattleController : BattleController
{
    List<Collider2D> Colliders { get; set; }

    //Те, которые указываются в редакторе Unity

    public GameObject HealthBarLine;
    public GameObject HealthBarTip;

    //Внутренние переменные
    private Image HealthBarLineImage;
    private RectTransform HealthBarRect;
    private RectTransform HealthBarTipRect;
    private float HealthBarMaxWidth;
    private float HealthBarTipDefaultX;

    protected override void Start()
    {
        base.Start();

        Colliders = new List<Collider2D>();
        movementController = GetComponent<PlayerMovementController>();
        animationController = GetComponent<PlayerAnimationController>();

        HealthBarLineImage = HealthBarLine.GetComponent<Image>();

        HealthBarRect = HealthBarLine.GetComponent<RectTransform>();
        HealthBarMaxWidth = HealthBarRect.rect.width;

        HealthBarTipRect = HealthBarTip.GetComponent<RectTransform>();
        HealthBarTipDefaultX = HealthBarTipRect.anchoredPosition.x;

        UpdateHealthBarLine();
    }

    void Update()
    {
        //SetHealthBarLine();
    }

    void UpdateHealthBarLine()
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

    IEnumerator HitEnemyCoroutine()
    {
        yield return new WaitForSeconds(HitDelay);

        var enemyCollider = Colliders.FirstOrDefault(c => c.gameObject.tag == "Enemy");
        if (enemyCollider != null)
        {
            var controllerScript = enemyCollider.gameObject.GetComponent<BattleController>();
            controllerScript.GetDamage(Damage);
        }
    }

    protected void OnTriggerExit2D(Collider2D collision) => Colliders.Remove(collision);
    protected void OnTriggerEnter2D(Collider2D collision) => Colliders.Add(collision);
}