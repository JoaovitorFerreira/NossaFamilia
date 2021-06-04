using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    public Rigidbody2D rig;
    public Animator animator;    
    public float speed = 10f;

    bool isWalking = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setVelocity(int direcao)
    {
        this.rig.velocity = new Vector2(direcao * this.speed, this.rig.velocity.y);
    }
    

    void defineWalkAnimation()
    {        
        animator.SetInteger("Transition", 1);
    }

    void defineIdleAnimation()
    {
        animator.SetInteger("Transition", 0);
    }

    public void walkRight(bool isJumping)
    {        

        setVelocity(1);
        transform.eulerAngles = new Vector2(0,0);       

        if(!isJumping)
        {
            defineWalkAnimation();               
        }     
    }

    public void walkLeft(bool isJumping)
    {           

        setVelocity(-1);
        transform.eulerAngles = new Vector2(0, 180);

        if(!isJumping)
        {
            defineWalkAnimation();            
        }        
    }

    public void stay(bool isJumping)
    {        

        setVelocity(0);

        if(!isJumping)
        {
            defineIdleAnimation();
        }        
    }

    public void stopVelocity()
    {
        setVelocity(0);
    }
}
