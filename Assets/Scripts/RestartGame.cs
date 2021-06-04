using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartGame: MonoBehaviour {

    
    public void MehtodRestartGame(){

        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("SampleScene");

    }
    public void GoToMenuGame(){

        SceneManager.LoadScene("StartMenu");
    }

}