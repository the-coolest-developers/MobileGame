using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{   //Внутренние переменные

    protected Animator EntityAnimator { get; set; }

    //Внешние переменные

    public string StrikeBoolName;

    public string RunningBoolName;


    // Start is called before the first frame update
    protected void Start()
    {
        EntityAnimator = GetComponent<Animator>();
    }
    // Update is called once per frame
    public void SetIsRunning() => EntityAnimator.SetBool(StrikeBoolName, true);
    public void SetIsNotRunning() => EntityAnimator.SetBool(StrikeBoolName, false);
    public void PlayStrikeAnimation() => EntityAnimator.Play(RunningBoolName);

}
