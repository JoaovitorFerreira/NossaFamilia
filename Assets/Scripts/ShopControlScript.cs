using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopControlScript : MonoBehaviour {

	float moneyAmount;
	int gunsForce;
	int health;

	public Text moneyAmountText;

	public Text subMachinePrice;
	public Button buySubMachineButton;

	public Text ak47Price;
	public Button buyAk47Button;

	public Text sniperPrice;
	public Button buySniperButton;

	public Text starPrice;
	public Button buyStarButton;

	GameObject playerObj;

	public int subMachineDamage = 3;
	public int sniperDamage = 5;
	public int akDamage = 7;

	float x;
	float y;
	float z;




	// Use this for initialization
	void Start () {
		//DontDestroyOnLoad(playerObj);
		moneyAmount = PlayerPrefs.GetFloat("MoneyAmount");
		gunsForce = PlayerPrefs.GetInt("gunsForce");
		health = PlayerPrefs.GetInt("health");

		x = PlayerPrefs.GetFloat("x");
		y = PlayerPrefs.GetFloat("y");
		z = PlayerPrefs.GetFloat("z");


		Debug.Log("ENTRANDO NO START DO SHOPPS");
		Debug.Log("Money: " + moneyAmount);
		Debug.Log("Guns Force: " + gunsForce);
		Debug.Log("Health: " + health);

		Debug.Log("x: " + x);
		Debug.Log("y: " + y);
		Debug.Log("z " + z);
				
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

		gunsForce = subMachineDamage;
	}
	
	public void buyAk47()
	{
		
		moneyAmount -= 500;
		ak47Price.text = "Sold!";
		buyAk47Button.gameObject.SetActive (false);

		gunsForce = akDamage;
	}

	public void buySniper()
	{
		
		moneyAmount -= 600;
		sniperPrice.text = "Sold!";
		buySniperButton.gameObject.SetActive (false);

		gunsForce = sniperDamage;
	}

	public void buyStar()
	{
		
		moneyAmount -= 500;
		health = 12;
		starPrice.text = "Sold!";
		buyStarButton.gameObject.SetActive (false);
	}

	public void exitShop()
	{
		Debug.Log("ENtra no exit SHOP");
		Debug.Log("Money logo antes de sair da loja: " + moneyAmount);

		PlayerPrefs.SetFloat ("MoneyAmount", moneyAmount);
		PlayerPrefs.SetInt ("gunsForce", gunsForce);
		PlayerPrefs.SetInt ("health", health);		

		PlayerPrefs.SetFloat("x", x);
		PlayerPrefs.SetFloat("y", y);
		PlayerPrefs.SetFloat("z", z);
		
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
