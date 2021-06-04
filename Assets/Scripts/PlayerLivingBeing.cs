using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLivingBeing : MonoBehaviour
{
    public Animator anim;
    public int health = 10;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Player>();
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

        player.hit(health);

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
            //anim.SetTrigger("death");

            SceneManager.LoadScene("StartMenu");

            //Destroy(gameObject, (float)1);
        }
    }
}
