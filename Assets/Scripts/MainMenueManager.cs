using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenueManager : MonoBehaviour
{
    public void startGame(string difficulty){
        PlayerState.SetDifficulty(difficulty);
        SceneManager.LoadScene(1);
    }

    public void quitGame(){
        Application.Quit();
    }
}
