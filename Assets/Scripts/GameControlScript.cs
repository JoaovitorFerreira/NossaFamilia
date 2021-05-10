using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControlScript : MonoBehaviour 
{
	public Text moneyText;
	public int moneyAmount;
	public GameObject rifle;
	int isRifleSold;
	GameObject playerObj = null;
	GameObject shopObj = null;

	// Use this for initialization
	void Start () {
		moneyAmount = 1000;
		
		// isRifleSold = PlayerPrefs.GetInt ("IsRifleSold");

		// if (isRifleSold == 0)
		// 	rifle.SetActive (true);
		// else
		// 	rifle.SetActive (false);

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
