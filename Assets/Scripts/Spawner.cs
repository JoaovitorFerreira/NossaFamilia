using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public GameObject runner;
    public GameObject shooter;

    public string dificult;
    int countRunners;
    int countShooters;
    public float distanceToSpawn = 17f;
    public float delayBetweenSpawns = 1;
    float timeToSpawnNext = 0f;
    GameObject player;
    bool startSpawn = false;

    float lastDistance;
    // Start is called before the first frame update
    void Start()
    {        
        player = GameObject.Find("Player");

        if(dificult == "hard")
        {
            countRunners = new System.Random().Next(2, 9);
            countShooters = new System.Random().Next(2, 9);
        }
        else if (dificult == "normal")
        {
            countRunners = new System.Random().Next(2, 5);
            countShooters = new System.Random().Next(2, 5);
        }
        
        Debug.Log("QUANTIDADE DE CADA");
        Debug.Log("QTD 1 " + countRunners);
        Debug.Log("QTD 2 " + countShooters);

    }

    // Update is called once per frame
    void Update()
    {    
        if(countRunners <= 0 && countShooters <= 0)
        {
            Destroy(gameObject);
        }

        if(startSpawn == true)
        {
            if(Time.time > timeToSpawnNext)
            {
                createEnemy();
            }
        }            
        else
        {
            checkIsInScene();            
        }
            
    }

    void createEnemy()
    {        
        Transform t = transform;
        t.eulerAngles = new Vector2(0, 180);

        timeToSpawnNext = delayBetweenSpawns + Time.time;

        if(countRunners > 0)
        {
            GameObject gOb1 = Instantiate(runner, new Vector3(transform.position.x, transform.position.y, -4), t.rotation);
            countRunners--;
        }
        else
        {
            GameObject gOb1 = Instantiate(shooter, new Vector3(transform.position.x, transform.position.y, -4), t.rotation);
            countShooters--;
        }
        
    }

    void checkIsInScene()
    {       
        float distance = transform.position.x - player.transform.position.x;
        
        
        if(distanceToSpawn < distance)
        {
            startSpawn = true;
            createEnemy();
        }
                            
        

        // if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        // {
        //     // Your object is in the range of the camera, you can apply your behaviour
        //     Debug.Log("Está em cena");

        //     //GameObject projetil = Instantiate(projetilPrefab, new Vector3(transform.position.x + 7, transform.position.y, -4), transform.rotation);
        // }
        // else
        // {

        // }
            // Debug.Log("Não está em cena");

    }
}
