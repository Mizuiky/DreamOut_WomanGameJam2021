using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    float amplitude = 0.05f;
    float frequency = 1f;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    private void Start()
    {
        posOffset = transform.position;
    }

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
    
    private void Update()
    {
        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }
}
