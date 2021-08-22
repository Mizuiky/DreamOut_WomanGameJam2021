using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    public void startGame()
    {
        this.gameObject.SetActive(true);
        this.animator.SetBool("hadRightHit", true);
    }

    public void stopGame()
    {
        this.gameObject.SetActive(false);
    }

    public void setAnimatorParameter(string name, bool b)
    {
        animator.SetBool(name, b);
    }
}
