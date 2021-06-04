using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControlScript : MonoBehaviour 
{
	public Text moneyText;
	public float moneyAmount;
	int gunsForce;
	int health;
	GameObject playerObj = null;
	GameObject shopObj = null;


	Player playerScript;
	LivingBeing livingBeingScript;
	Shooter shooterScript; 
	int flagSetValues;

	float x;
	float y;
	float z;
	Vector3 playerpos;

	// Use this for initialization
	void Start () {

		playerScript = gameObject.GetComponent<Player>();
		livingBeingScript = gameObject.GetComponent<LivingBeing>();
		shooterScript = gameObject.GetComponent<Shooter>();
		

		if(PlayerPrefs.GetInt("gunsForce") == 0)
			PlayerPrefs.DeleteAll();

		if (playerObj == null)
			playerObj = GameObject.Find("Player");
		if (shopObj == null)
             shopObj = GameObject.Find("Shop");


		if(PlayerPrefs.HasKey("MoneyAmount") && PlayerPrefs.HasKey("gunsForce") &&
			PlayerPrefs.HasKey("health") && PlayerPrefs.HasKey("x") &&
			PlayerPrefs.HasKey("y") && PlayerPrefs.HasKey("z"))
		{
			moneyAmount = PlayerPrefs.GetFloat("MoneyAmount");
			gunsForce = PlayerPrefs.GetInt("gunsForce");
			health = PlayerPrefs.GetInt("health");			
			x = PlayerPrefs.GetFloat("x");
			y = PlayerPrefs.GetFloat("y");
			z = PlayerPrefs.GetFloat("z");

			Debug.Log("START DO GAME CONTROL");

			Debug.Log("moneyAmount: " + moneyAmount);
			Debug.Log("gunsForce: " + gunsForce);
			Debug.Log("health: " + health);

			Debug.Log("x: " + x);
			Debug.Log("y: " + y);
			Debug.Log("z: " + z);

			setValues();
		}

		


		if (flagSetValues == 200)
		{
			Debug.Log("DENTRO DO IF DO FLAG SET VALUES");

			Debug.Log("moneyAmount: " + moneyAmount);
			Debug.Log("gunsForce: " + gunsForce);
			Debug.Log("health: " + health);

			Debug.Log("x: " + x);
			Debug.Log("y: " + y);
			Debug.Log("z: " + z);

			
		}
						
		//moneyAmount = PlayerPrefs.GetInt("MoneyAmount");
		
		
	}
	
	// Update is called once per frame
	void Update () {
		moneyText.text = "Money:"+ playerScript.getMoneyAmount().ToString() + "C";
		gotoShop();
	}

	void setValues()
	{
		Debug.Log("ENTRANDO NO SET VALUES");

		playerScript.setMoneyAmount(moneyAmount);
		playerScript.setPlayerPosition(x, y, z);
		livingBeingScript.setHealth(health);
		shooterScript.setProjetilDamage(gunsForce);
	}

	public void gotoShop()
	{		

		// Ir para loja com um botão		
		float distance = playerObj.transform.position.x - shopObj.transform.position.x;

		if (distance < 2 && distance > -2) {

			if(Input.GetKeyDown(KeyCode.E)){				

				if(gunsForce == 0)
				{
					gunsForce = shooterScript.getProjetilDamage();
					health = livingBeingScript.getHealth();
					moneyAmount = playerScript.getMoneyAmount();

					Transform playerTransform = playerObj.transform;

					x = playerTransform.position.x;
					y = playerTransform.position.y;
					z = playerTransform.position.z;
				}

				Debug.Log("Guns Force : " + gunsForce);
				Debug.Log("Health : " + health);

				PlayerPrefs.SetFloat("MoneyAmount", moneyAmount);
				PlayerPrefs.SetInt("gunsForce", gunsForce);
				PlayerPrefs.SetInt("health", health);	

				PlayerPrefs.SetFloat("x", x);
				PlayerPrefs.SetFloat("y", y);
				PlayerPrefs.SetFloat("z", z);							


				 SceneManager.LoadScene("ShopScene");

			}
		}
	}

}
