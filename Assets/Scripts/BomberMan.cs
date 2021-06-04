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
    float timeShooting = 2;
    GameObject player;
    bool timeToWalk = true;
    float walkingTime = 1f;
    float shootingTime = 0.3f;
    float nextChangeTime;
    Walker walkerScript;
    Shooter shooterScript;
    CloseAtacker attackerScript;
    bool facingRight = false;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        walkerScript = gameObject.GetComponent<Walker>();
        shooterScript = gameObject.GetComponent<Shooter>();
        attackerScript = gameObject.GetComponent<CloseAtacker>();
        nextChangeTime = Time.time + walkingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextChangeTime)
        {
            if(timeToWalk)
                nextChangeTime = Time.time + shootingTime;
            else
                nextChangeTime = Time.time + walkingTime;

            timeToWalk = !timeToWalk;
        }

        // if (timeRemaining > 0)
        // {
        //     timeRemaining -= Time.deltaTime;
        //     isWalking = false;
        // }
        // else
        // {
        //     timeRemaining = 10;
        //     isWalking = true;

        // }

    }

    void FixedUpdate()
    {
        makeDecision();        
    }

    void makeDecision()
    {
        float distance = player.transform.position.x - transform.position.x;        

        if (distance < 0.7 && distance > -0.7)
        {
            attack();
        }
        else
        {            
            if (timeToWalk)
            {                
                walk(distance);
            }
            else
            {
                shoot();
            }
        }

    }


    void walk(float distance)
    {

        if (distance < 0)
        {
            facingRight = false;
            walkerScript.walkLeft(false);
        }
        else
        {
            facingRight = true;
            walkerScript.walkRight(false);
        }

    }

    void attack()
    {
        walkerScript.stopVelocity();        
        attackerScript.attack();        
    }

    void shoot()
    {
        walkerScript.stay(false);

        shooterScript.shoot(facingRight, false);
    }

}
