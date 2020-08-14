using UnityEngine;
using UnityEngine.Serialization;

namespace Controllers.EntityControllers
{
    public class AnimationController : MonoBehaviour
    {
        //Внутренние переменные
        private Animator EntityAnimator { get; set; }

        //Внешние переменные

        [FormerlySerializedAs("StrikeBoolName")]
        public string strikeBoolName;

        [FormerlySerializedAs("RunningBoolName")]
        public string runningBoolName;


        // Start is called before the first frame update
        private void Start()
        {
            EntityAnimator = GetComponent<Animator>();
        }

        // Update is called once per frame
        public void SetIsRunning()
        {
            if (EntityAnimator != null)
            {
                EntityAnimator.SetBool(runningBoolName, true);
            }
        }

        public void SetIsNotRunning()
        {
            if (EntityAnimator != null)
            {
                EntityAnimator.SetBool(runningBoolName, false);
            }
        }

        public void PlayStrikeAnimation()
        {
            if (EntityAnimator != null)
            {
                EntityAnimator.Play(strikeBoolName);
            }
        }
    }
}