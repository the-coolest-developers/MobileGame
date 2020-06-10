using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator PlayerAnimator { get; set; }

    void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
    }

    //public void SetIsRunning() => PlayerAnimator.SetBool("IsRunning", true);
    public void SetIsRunning()
    {
        PlayerAnimator.SetBool("IsRunning", true);
        Debug.Log("IsRunning");
    }
    public void SetIsNotRunning() => PlayerAnimator.SetBool("IsRunning", false);

    public void PlayStrikeAnimation()
    {
        PlayerAnimator.Play("Strike");
    }

}
