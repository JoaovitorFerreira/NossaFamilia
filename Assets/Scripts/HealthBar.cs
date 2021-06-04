using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour  {

    public Sprite[] bar;
    public Image healthBarUi;

    private LivingBeing player;

    void Start() {
        player = GameObject.Find("Player").GetComponent<LivingBeing>();
    }


    void Update() {
        if(player.health <= 0)
        {
            SceneManager.LoadScene("Restart");
        }

        healthBarUi.sprite = bar[player.health];
    }
}