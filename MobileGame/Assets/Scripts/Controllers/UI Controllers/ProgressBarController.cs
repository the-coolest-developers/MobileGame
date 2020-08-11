using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Controllers.UI_Controllers
{
    public class ProgressBarController : MonoBehaviour
    {
        //Из редактора
        public string ProgressBarName;

        public string LineGameObjectName;
        public string BarTipGameObjectName;
        /// <summary>
        /// Масштаб обьекта в редакторе. Необходимо для правильных вычислений
        /// </summary>
        public float LineScale;

        public GameObject LineGameObject { get; set; }
        public GameObject TipGameObject { get; set; }

        //Внутренние
        private Image LineImage;
        private RectTransform Rect;
        private RectTransform TipRect;
        private float MaxWidth;
        private float DefaultX;

        private void Start()
        {
            LineGameObject = GameObject.Find(LineGameObjectName);
            TipGameObject = GameObject.Find(BarTipGameObjectName);

            LineImage = LineGameObject.GetComponent<Image>();
            Rect = LineGameObject.GetComponent<RectTransform>();
            MaxWidth = Rect.rect.width;
            TipRect = TipGameObject.GetComponent<RectTransform>();
            DefaultX = TipRect.anchoredPosition.x;
        }

        public void UpdateLine(float currentValue, float maxValue)
        {
            float valuePercent = currentValue / maxValue;
            if (valuePercent > 1)
            {
                valuePercent = 1;
            }

            if (LineImage != null)
            {
                LineImage.fillAmount = valuePercent;

                if (valuePercent > 0)
                {
                    TipGameObject.SetActive(true);

                    var tipPosX = valuePercent * MaxWidth * LineScale;
                    TipRect.anchoredPosition = new Vector2(DefaultX + tipPosX, TipRect.anchoredPosition.y);
                }
                else
                {
                    TipGameObject.SetActive(false);
                }
            }
        }
    }
}
