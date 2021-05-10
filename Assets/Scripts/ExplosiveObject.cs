using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveObject : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public Rigidbody2D rig;
    GameObject player;
    public int fullDamage = 4; 

    public int verticalForceMin = 2;
    public int verticalForceMax = 4;

    public int horizontalForceMin = 2;
    public int horizontalForceMax = 4;

    void Start()
    {
        player = GameObject.Find("Player");

        throwObject();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void throwObject()
    {
        int verticalForce = new System.Random().Next(verticalForceMin, verticalForceMax);
        int speed = new System.Random().Next(horizontalForceMin, horizontalForceMax);

        float distanceToPlayer = player.transform.position.x - transform.position.x;

        rig.AddForce(Vector2.up * verticalForce, ForceMode2D.Impulse);

        if(distanceToPlayer < 0) 
            rig.velocity = new Vector2(-speed, rig.velocity.y);
        else
            rig.velocity = new Vector2(speed, rig.velocity.y);
        
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            if(other.CompareTag("Player"))
            {
                rig.gravityScale = 0;
                rig.velocity = new Vector2(0, 0);

                animator.SetInteger("transition", 1);
                Destroy(gameObject, (float)0.55);

                other.GetComponent<LivingBeing>().onHit(fullDamage);
            }

            if(other.CompareTag("Floor"))
            {
                rig.gravityScale = 0;
                rig.velocity = new Vector2(0, 0);

                animator.SetInteger("transition", 1);
                Destroy(gameObject, (float)0.55);

                if(transform.position.x - player.transform.position.x < 5 && transform.position.x - player.transform.position.x > -5)                    
                other.GetComponent<LivingBeing>().onHit(fullDamage/2);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo != null)
        {
            animator.SetInteger("transition", 1);
        }

        Invoke("destroyEnemy", (float)0.55);
    }

    void destroyEnemy()
    {
        Destroy(gameObject);
    }
}
