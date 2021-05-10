using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public GameObject projetilPrefab;
    public GameObject enemyProjetilPrefab;
    public Transform shootPoint;
    public Animator anim;
    public float fireRate = 2f;
    public float projetilSpeed = 5f;
    float nextTime = 0f;



     
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shoot(bool facingRight, bool hitEnemy)
    {
        if(Time.time > nextTime)
        {            
            nextTime = Time.time + fireRate;

            anim.SetTrigger("shoot");

            GameObject projetil;

            if(hitEnemy)
            {
                Debug.Log("Entra no primeiro");
                projetil = Instantiate(projetilPrefab, new Vector3(shootPoint.position.x, shootPoint.position.y, -4), transform.rotation);
            }                
            else
            {
                Debug.Log("Entra no segundo");
                projetil = Instantiate(enemyProjetilPrefab, new Vector3(shootPoint.position.x, shootPoint.position.y, -4), transform.rotation);
            }
                              

            if(facingRight)
                projetil.GetComponent<Rigidbody2D>().velocity = new Vector2(projetilSpeed, 0);
            else
                projetil.GetComponent<Rigidbody2D>().velocity = new Vector2(-projetilSpeed, 0);
        }
    }
}
