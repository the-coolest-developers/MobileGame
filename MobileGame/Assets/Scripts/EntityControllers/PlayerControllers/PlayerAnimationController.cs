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

    public void SetIsRunning() => PlayerAnimator.SetBool("IsRunning", true);
    public void SetIsNotRunning() => PlayerAnimator.SetBool("IsRunning", false);

    public void RunFullStrikeAnimation()
    {

        Task.Run(() =>
        {
            Invoke("SetIsStriking", 0);
            //SetIsStriking();
            Thread.Sleep(5);
            SetIsNotStriking();
        });
    }
    public void SetIsStriking() => PlayerAnimator.SetBool("Fight", true);
    public void SetIsNotStriking() => PlayerAnimator.SetBool("Fight", false);

}
