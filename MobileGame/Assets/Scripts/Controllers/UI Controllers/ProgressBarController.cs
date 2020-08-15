using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Controllers.UI_Controllers
{
    public class ProgressBarController : MonoBehaviour
    {
        //Из редактора
        [FormerlySerializedAs("ProgressBarName")]
        public string progressBarName;

        [FormerlySerializedAs("LineGameObjectName")]
        public string lineGameObjectName;
        [FormerlySerializedAs("BarTipGameObjectName")]
        public string barTipGameObjectName;
        /// <summary>
        /// Масштаб обьекта в редакторе. Необходимо для правильных вычислений
        /// </summary>
        [FormerlySerializedAs("LineScale")]
        public float lineScale;

        public GameObject LineGameObject { get; set; }
        public GameObject TipGameObject { get; set; }

        //Внутренние
        private Image _lineImage;
        private RectTransform _rect;
        private RectTransform _tipRect;
        private float _maxWidth;
        private float _defaultX;

        private void Start()
        {
            LineGameObject = GameObject.Find(lineGameObjectName);
            TipGameObject = GameObject.Find(barTipGameObjectName);

            _lineImage = LineGameObject.GetComponent<Image>();
            _rect = LineGameObject.GetComponent<RectTransform>();
            _maxWidth = _rect.rect.width;
            _tipRect = TipGameObject.GetComponent<RectTransform>();
            _defaultX = _tipRect.anchoredPosition.x;
        }

        public void UpdateLine(float currentValue, float maxValue)
        {
            float valuePercent = currentValue / maxValue;
            if (valuePercent > 1)
            {
                valuePercent = 1;
            }

            if (_lineImage != null)
            {
                _lineImage.fillAmount = valuePercent;

                if (valuePercent > 0)
                {
                    TipGameObject.SetActive(true);

                    var tipPosX = valuePercent * _maxWidth * lineScale;
                    _tipRect.anchoredPosition = new Vector2(_defaultX + tipPosX, _tipRect.anchoredPosition.y);
                }
                else
                {
                    TipGameObject.SetActive(false);
                }
            }
        }
    }
}
