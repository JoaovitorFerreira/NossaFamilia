using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingBeing : MonoBehaviour
{
    public Animator anim;
    public int health = 12;

    public AudioClip audioClip;
    public AudioSource audioSource;

    public GameObject player;

    //Player player;

    // Start is called before the first frame update
    void Start()
    {                
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        checkIsAlive();
    }

    public void setHealth(int health)
    {
        this.health = health;
    }

    public int getHealth()
    {
        return health;
    }

    public void onHit(int damage)
    {        
        health -= damage;
        
        audioSource.PlayOneShot(audioClip);

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
            
            Invoke("destroyLiving", (float)1);
        }
    }

    void destroyLiving()
    {
        player.GetComponent<Player>().addMoney(100);
        Destroy(gameObject);
    }
}
