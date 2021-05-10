using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingBeing : MonoBehaviour
{
    public Animator anim;
    public int health = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkIsAlive();
    }

    public void onHit(int damage)
    {        
        health -= damage;

        if(health >= 0)
        {
            anim.SetTrigger("sufferDamage");
        }

        checkIsAlive();
    }

    void checkIsAlive()
    {
        if(health <= 0)
        {
            anim.SetTrigger("death");    
            Destroy(gameObject, (float)1);
        }
    }
}
