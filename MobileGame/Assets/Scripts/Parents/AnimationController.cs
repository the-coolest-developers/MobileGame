using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{   //Внутренние переменные
    
    protected Animator PlayerAnimator { get; set; }
    
    //Внешние переменные
    
    public string StrikeBoolName;

    public string RunningBoolName;


    // Start is called before the first frame update
    protected void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
    }
    // Update is called once per frame
    public void SetIsRunning() => PlayerAnimator.SetBool(StrikeBoolName, true);
    
    public void SetIsNotRunning() => PlayerAnimator.SetBool(StrikeBoolName, false);

    public void PlayStrikeAnimation() => PlayerAnimator.Play(RunningBoolName);
    
}
