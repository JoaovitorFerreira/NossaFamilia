using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{   
    Walker walkerScript;
    Jumper jumperScript;
    Shooter shooterScript;

    public float money = 0f;

    bool facingRight = true;

    public int health = 12;

    // Start is called before the first frame update
    void Start()
    {
       walkerScript = gameObject.GetComponent<Walker>();
       jumperScript =  gameObject.GetComponent<Jumper>();
       shooterScript = gameObject.GetComponent<Shooter>();
    }

    public void hit(int health)
    {
        this.health = health;  
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            changeScene();
        }
    }



    public void changeScene()
    {
        SceneManager.LoadScene("StartMenu");
    }

    void FixedUpdate()
    {
        walk();
        jump();
        shoot();
    }

    public void addMoney(float qnt)
    {
        Debug.Log("ENTRA NO ADD MONEY");

        money += qnt;
    }

    public void setPlayerPosition(float x, float y, float z)
    {
        Vector3 vec = new Vector3(x, y, z);
        transform.position = vec;
    }
    public void setMoneyAmount(float money)
    {
        Debug.Log("ENTRANDO NO SET MONEY AMOUNT");
        this.money = money;
    }

    public float getMoneyAmount()
    {
        return money;
    }

    void walk()
    {
        float direcao = Input.GetAxis("Horizontal");                
    

        if(direcao > 0)
        {
            facingRight = true;
            walkerScript.walkRight(jumperScript.isJumping());
        }
        else if (direcao < 0)
        {            
            facingRight = false;
            walkerScript.walkLeft(jumperScript.isJumping());
        }
        else if(direcao == 0) 
        {
            walkerScript.stay(jumperScript.isJumping());
        }            
    }

    void jump()
    {         
        if(Input.GetButtonDown("Jump") && !jumperScript.isJumping())
        {                                
            gameObject.GetComponent<Jumper>().jump();
        }        
    }

    void shoot()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            shooterScript.shoot(facingRight, true);
        }
    }

    

}
