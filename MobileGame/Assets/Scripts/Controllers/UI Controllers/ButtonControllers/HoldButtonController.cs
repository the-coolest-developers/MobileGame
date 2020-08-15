using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace Controllers.UI_Controllers.ButtonControllers
{
    public class HoldButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public event Action ButtonClick;
        public event Action ButtonHold;
        public event Action<float> ButtonDown;

        public bool PointerDown { get; set; }
        public float HoldTimer { get; set; }

        //Из редактора
        [FormerlySerializedAs("RequiredHoldTime")]
        public float requiredHoldTime;
        [FormerlySerializedAs("MaximumHoldTime")]
        public float maximumHoldTime;

        [FormerlySerializedAs("InfiniteHold")]
        public bool infiniteHold;

        public void OnPointerDown(PointerEventData eventData)
        {
            PointerDown = true;
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            if (PointerDown)
            {
                if (HoldTimer >= requiredHoldTime)
                {
                    ButtonHold();
                }
                else
                {
                    ButtonClick();
                }

                Reset();
            }
        }

        private void Reset()
        {
            PointerDown = false;
            HoldTimer = 0;
        }

        public void Start()
        {
            Reset();

            ButtonClick = new Action(() => { });
            ButtonHold = new Action(() => { });
            ButtonDown = new Action<float>((f) => { });
        }

        public void Update()
        {
            if (PointerDown)
            {
                HoldTimer += Time.deltaTime;

                if (!infiniteHold && HoldTimer >= maximumHoldTime)
                {
                    ButtonHold();
                    Reset();
                }
                else
                {
                    ButtonDown(HoldTimer);
                }
            }
        }
    }
}
