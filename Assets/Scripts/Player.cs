using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    Walker walkerScript;
    Jumper jumperScript;
    Shooter shooterScript;

    bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
       walkerScript = gameObject.GetComponent<Walker>();
       jumperScript =  gameObject.GetComponent<Jumper>();
       shooterScript = gameObject.GetComponent<Shooter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        walk();
        jump();
        shoot();
    }

    void walk()
    {
        float direcao = Input.GetAxis("Horizontal");                
    

        if(direcao > 0)
        {
            facingRight = true;
            walkerScript.walkRight(jumperScript.isJumping());
        }
        else if (direcao < 0)
        {            
            facingRight = false;
            walkerScript.walkLeft(jumperScript.isJumping());
        }
        else if(direcao == 0) 
        {
            walkerScript.stay(jumperScript.isJumping());
        }            
    }

    void jump()
    {         
        if(Input.GetButtonDown("Jump") && !jumperScript.isJumping())
        {                                
            gameObject.GetComponent<Jumper>().jump();
        }        
    }

    void shoot()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            shooterScript.shoot(facingRight, true);
        }
    }

    

}
