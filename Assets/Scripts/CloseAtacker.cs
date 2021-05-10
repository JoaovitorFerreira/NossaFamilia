using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAtacker : MonoBehaviour
{
    public Animator anim;
    int damage = 3;
    public float atkRadius = 0.5f;
    public LayerMask playerLayer;
    public Transform atkPoint;
    public float attackRate = 0.3f;
    float lastAttack = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void attack()
    {   
        if(Time.time > lastAttack + attackRate)
        {
            lastAttack = Time.time;

            Debug.Log("Entra dentro do método de ataque da classe close atacker");

            anim.SetTrigger("closeAttack");

            Collider2D  hit = Physics2D.OverlapCircle(atkPoint.position, atkRadius, playerLayer);
        
            Debug.Log("Informação do hit: " + hit);

            if(hit != null)
            {
                Debug.Log("Ta acertando o player");
                hit.GetComponent<LivingBeing>().onHit(damage);
                // if(hit.gameObject.layer == 9)
                // {
                    
                // }            
            }
        }   

    }


}
