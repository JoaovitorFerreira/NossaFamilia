using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopControlScript : MonoBehaviour {

	int moneyAmount;

	public Text moneyAmountText;

	public Text subMachinePrice;
	public Button buySubMachineButton;

	public Text ak47Price;
	public Button buyAk47Button;

	public Text sniperPrice;
	public Button buySniperButton;

	public Text starPrice;
	public Button buyStarButton;

	GameObject playerObj = GameObject.Find("Player");


	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(playerObj);
		moneyAmount = PlayerPrefs.GetInt("MoneyAmount");
				
	}
	
	// Update is called once per frame
	void Update () {
		
		moneyAmountText.text = "Money:"+ moneyAmount.ToString() + "C";

		if (moneyAmount >= 200)
			buySubMachineButton.interactable = true;
		else
			buySubMachineButton.interactable = false;	

		if (moneyAmount >= 500)
			buyAk47Button.interactable = true;
		else
			buyAk47Button.interactable = false;
		
		if (moneyAmount >= 600)
			buySniperButton.interactable = true;
		else
			buySniperButton.interactable = false;
		
		if (moneyAmount >= 1000)
			buyStarButton.interactable = true;
		else
			buyStarButton.interactable = false;
	}

	public void buySubMachine()
	{		
		moneyAmount -= 200;
		subMachinePrice.text = "Sold!";
		buySubMachineButton.gameObject.SetActive(false);
	}
	
	public void buyAk47()
	{
		
		moneyAmount -= 500;
		ak47Price.text = "Sold!";
		buyAk47Button.gameObject.SetActive (false);
	}

	public void buySniper()
	{
		
		moneyAmount -= 600;
		sniperPrice.text = "Sold!";
		buySniperButton.gameObject.SetActive (false);
	}

	public void buyStar()
	{
		
		moneyAmount -= 1000;
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
