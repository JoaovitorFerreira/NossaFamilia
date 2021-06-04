using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public Rigidbody2D rig;
    public Animator anim;
    public float jumpForce = 5f;

    bool jumping = false;  


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isJumping()
    {
        return jumping;
    }

    public void jump()
    {
        if(!jumping)
        {
            this.jumping = true;
            
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetInteger("transition", 2);
        }
    }


    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo != null)
        {
            if(collisionInfo.gameObject.layer == 8)
            {
                jumping = false;
            }            
        }    
    }

}
