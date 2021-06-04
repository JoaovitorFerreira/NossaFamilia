using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowerEnemy : MonoBehaviour
{
    public GameObject bombPrefab;
    public int minTime = 2;
    public int maxTime = 6;

    float nextThrow = 0;

    GameObject player;



    // Start is called before the first frame update
    void Start()
    {        
        nextThrow = Time.time + getRandomValueBetweenMinAndMax();

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        lookToPlayer();
        createExplosiveBarrel();
    }

    float getRandomValueBetweenMinAndMax()
    {
        return new System.Random().Next(minTime, maxTime);
    }

    void lookToPlayer()
    {
        float distanceToPlayer = player.transform.position.x - transform.position.x;

        if(distanceToPlayer < 0)
        {
            transform.eulerAngles = new Vector2(0,180);
        }
        else
        {
            transform.eulerAngles = new Vector2(0,0);
        }
    }

    void createExplosiveBarrel()
    {         
         if(Time.time > nextThrow)
         {
             nextThrow = Time.time + getRandomValueBetweenMinAndMax();

             GameObject bomb = Instantiate(bombPrefab, new Vector3(transform.position.x - 1, transform.position.y, -2), transform.rotation);
         }        
    }
}
