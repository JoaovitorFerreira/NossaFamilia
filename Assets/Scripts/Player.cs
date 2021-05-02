using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Animator animator;
    public Rigidbody2D rigidbody;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Walk();


    }

    void Walk()
    {
        float direcao = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(direcao * speed, rigidbody.velocity.y);

        if (direcao > 0)
        {
            transform.eulerAngles = new Vector2(0,0);
            animator.SetInteger("Transition", 1);
        }

        if (direcao < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
            animator.SetInteger("Transition", 1);
        }
        if (direcao ==0)
        {
            animator.SetInteger("Transition", 0);
        }

    }

}
