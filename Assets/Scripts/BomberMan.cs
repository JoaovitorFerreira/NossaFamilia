using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BomberMan : MonoBehaviour
{

    public Animator animator;
    public Rigidbody2D rigidbody;
    public float speed;
    public float timeRemaining = 10;
    public bool isWalking = true;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            isWalking = false;
        }
        else
        {
            timeRemaining = 10;
            isWalking = true;

        }

    }

    void FixedUpdate()
    {
        Walk();
    }

    void Walk()
    {
        if (isWalking)
        {
            rigidbody.velocity = new Vector2(-1 * speed, rigidbody.velocity.y);
            //personagem vira pros lados
                transform.eulerAngles = new Vector2(0, 180);
                animator.SetInteger("Transition", 1);


        }
        else
        {
                animator.SetInteger("Transition", 0);
        }

    }

}
