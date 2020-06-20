using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Parents;

public class PlayerBattleController : BattleController
{
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

        MovementController = GetComponent<PlayerMovementController>();
        AnimationController = GetComponent<PlayerAnimationController>();

        HealthBarLineImage = HealthBarLine.GetComponent<Image>();

        HealthBarRect = HealthBarLine.GetComponent<RectTransform>();
        HealthBarMaxWidth = HealthBarRect.rect.width;

        HealthBarTipRect = HealthBarTip.GetComponent<RectTransform>();
        HealthBarTipDefaultX = HealthBarTipRect.anchoredPosition.x;

        UpdateHealthBarLine();
    }

    void Update()
    {
        UpdateHealthBarLine();
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
}