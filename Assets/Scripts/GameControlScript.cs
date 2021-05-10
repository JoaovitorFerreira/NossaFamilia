using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControlScript : MonoBehaviour 
{
	public Text moneyText;
	public int moneyAmount;
	GameObject playerObj = null;
	GameObject shopObj = null;

	Vector3 playerpos;

	// Use this for initialization
	void Start () {
		
		moneyAmount = PlayerPrefs.GetInt("MoneyAmount");
		if (playerObj == null)
			playerObj = GameObject.Find("Player");
		if (shopObj == null)
             shopObj = GameObject.Find("Shop");
		
	}
	// Update is called once per frame
	void Update () {
		moneyText.text = "Money:"+ moneyAmount.ToString() + "C";
		gotoShop();
	}

	public void gotoShop()
	{		

		// Ir para loja com um botão		
		float distance = playerObj.transform.position.x - shopObj.transform.position.x;

		if (distance < 2 && distance > -2) {

			if(Input.GetKeyDown(KeyCode.E)){				

				PlayerPrefs.SetInt("MoneyAmount", moneyAmount);
				 SceneManager.LoadScene("ShopScene");

			}
		}
	}

}
