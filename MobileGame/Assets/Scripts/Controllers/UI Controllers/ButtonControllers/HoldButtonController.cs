using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Controllers.UI_Controllers.ButtonControllers
{
    public class HoldButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public event Action Button_Click;
        public event Action Button_Hold;
        public event Action<float> Button_Down;

        public bool PointerDown { get; set; }
        public float HoldTimer { get; set; }

        //Из редактора
        public float RequiredHoldTime;

        public void OnPointerDown(PointerEventData eventData)
        {
            PointerDown = true;
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            if (HoldTimer >= RequiredHoldTime)
            {
                Button_Hold();
                print("hold");
            }
            else
            {
                Button_Click();
                print("click");
            }

            Reset();
        }

        void Reset()
        {
            PointerDown = false;
            HoldTimer = 0;
        }

        public void Start()
        {
            Reset();

            Button_Click = new Action(() => { });
            Button_Hold = new Action(() => { });
            Button_Down = new Action<float>((f) => { });
        }

        public void Update()
        {
            if (PointerDown)
            {
                HoldTimer += Time.deltaTime;
                Button_Down(HoldTimer);
            }
        }
    }
}
