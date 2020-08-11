using UnityEngine;

namespace Controllers.EntityControllers
{
    public class AnimationController : MonoBehaviour
    {
        //Внутренние переменные
        private Animator EntityAnimator { get; set; }

        //Внешние переменные

        public string StrikeBoolName;

        public string RunningBoolName;


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
                EntityAnimator.SetBool(RunningBoolName, true);
            }
        }

        public void SetIsNotRunning()
        {
            if (EntityAnimator != null)
            {
                EntityAnimator.SetBool(RunningBoolName, false);
            }
        }

        public void PlayStrikeAnimation()
        {
            if (EntityAnimator != null)
            {
                EntityAnimator.Play(StrikeBoolName);
            }
        }
    }
}