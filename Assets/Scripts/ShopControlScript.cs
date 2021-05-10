using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopControlScript : MonoBehaviour {

	int moneyAmount;

	public Text moneyAmountText;
	public Text riflePrice;
	public Button buyButton;

	public Text starPrice;
	public Button buyStarButton;

	int isRifleSold;

	// Use this for initialization
	void Start () {
		moneyAmount = PlayerPrefs.GetInt("MoneyAmount");

		// if (moneyAmount >= 100) //valor do rifle setado manualmente
		// {
		// 	Debug.Log("ENTRA no interectable");
		// 	buyButton.interactable = true;
		// }		
		// else
		// {
		// 	Debug.Log("ENTRA no else");
		// 	buyButton.interactable = false;
		// }
				
	}
	
	// Update is called once per frame
	void Update () {
		
		moneyAmountText.text = "Money: " + moneyAmount.ToString() + "$";

		isRifleSold = PlayerPrefs.GetInt ("IsRifleSold");

		if (moneyAmount >= 5)
			buyButton.interactable = true;
		else
			buyButton.interactable = false;	
	}

	public void buyRifle()
	{		
		Debug.Log("ENTRA NO BUY RIFLE");
		moneyAmount -= 100;
		riflePrice.text = "Sold!";
		buyButton.gameObject.SetActive (false);
	}
	public void buyStar()
	{
		if (moneyAmount >= 300) //valor do rifle setado manualmente
			buyStarButton.interactable = true;
		else
			buyStarButton.interactable = false;	

		moneyAmount -= 300;
		starPrice.text = "Sold!";
		buyStarButton.gameObject.SetActive (false);
	}

	public void exitShop()
	{
		PlayerPrefs.SetInt ("MoneyAmount", moneyAmount);
		SceneManager.LoadScene ("SampleScene");
	}

	// -- PARA QUANDO MORRER O PERSONAGEM --

	// public void resetPlayerPrefs()
	// {
	// 	moneyAmount = 0;
	// 	buyButton.gameObject.SetActive (true);
	// 	riflePrice.text = "Price: 5$";
	// 	PlayerPrefs.DeleteAll ();
	// }

}
