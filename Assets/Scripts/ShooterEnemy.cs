using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    public int minWaitTimeToShoot = 1;
    public int mmaxWaitTimeToShoot = 3;

    public int minTimeShooting = 1;
    public int maxTimeShooting = 3;

    float nextChangeTime = 0;
    bool haveToShoot = false;
    GameObject player;

    Shooter shooterScript;
    bool facingRight;

    void Start()
    {
        shooterScript = GetComponent<Shooter>();
        player = GameObject.Find("Player");
        nextChangeTime = Time.time + getRandomNumberBetweenMinAndMax(minWaitTimeToShoot, mmaxWaitTimeToShoot);
    }

    // Update is called once per frame
    void Update()
    {
        lookAtPlayer();
        makeDecision();        
    }

    void makeDecision()
    {
        if(Time.time > nextChangeTime)
        {
            haveToShoot = !haveToShoot;

            if(haveToShoot)
                nextChangeTime = Time.time + getRandomNumberBetweenMinAndMax(minTimeShooting, maxTimeShooting);
            else
                nextChangeTime = Time.time + getRandomNumberBetweenMinAndMax(minWaitTimeToShoot, mmaxWaitTimeToShoot);
        }
            

        if(haveToShoot)
            shoot();
                
    }

    void lookAtPlayer()
    {
        float distance = player.transform.position.x - transform.position.x;

        if(distance < 0)
        {
            facingRight = false;
            transform.eulerAngles = new Vector2(0, 180);
        }
        else
        {
            facingRight = true;
            transform.eulerAngles = new Vector2(0, 0);
        }
    }

    void shoot()
    {
        shooterScript.shoot(facingRight, false);
    }

    float getRandomNumberBetweenMinAndMax(int min, int max)
    {
        return new System.Random().Next(min, max);
    }
}
