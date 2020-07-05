using Controllers.EntityControllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.UI_Controllers
{
    public class HealthBarController : MonoBehaviour
    {
        //Те, которые указываются в редакторе Unity
        public GameObject HealthBarLine;
        public GameObject HealthBarTip;

        //Внутренние
        private Image HealthBarLineImage;
        private RectTransform HealthBarRect;
        private RectTransform HealthBarTipRect;
        private float HealthBarMaxWidth;
        private float HealthBarTipDefaultX;

        protected virtual void Start()
        {
            HealthBarLineImage = HealthBarLine.GetComponent<Image>();
            HealthBarRect = HealthBarLine.GetComponent<RectTransform>();
            HealthBarMaxWidth = HealthBarRect.rect.width;
            HealthBarTipRect = HealthBarTip.GetComponent<RectTransform>();
            HealthBarTipDefaultX = HealthBarTipRect.anchoredPosition.x;
        }

        public void UpdateHealthBarLine(float currentHealth, float maxHealth)
        {
            float healthPercent = currentHealth / maxHealth;

            if (HealthBarLineImage != null)
            {
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
    }
}