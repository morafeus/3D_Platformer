using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Utils
{
    public static IEnumerator CoroutuneIdle(Animator animator) // запуск анимации idle при отсутствии нажатых клавиш
    {
        while (!Input.anyKey)
        {
            animator.SetBool("IsMoving", false);
            yield return null;
        }
        
    }

    public static IEnumerator CoroutuneRun(Animator animator)
    {
        while(Input.GetKey(KeyCode.W) 
            || Input.GetKey(KeyCode.S) 
            || Input.GetKey(KeyCode.A) 
            || Input.GetKey(KeyCode.D)) 
           
        {

            animator.SetBool("IsRun", true);
            if (Input.GetKey(KeyCode.S) )
                animator.SetBool("IsRunAway", true);
            yield return null;
        }
        animator.SetBool("IsRun", false);
        animator.SetBool("IsRunAway", false);
    }

  
}
