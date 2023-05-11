using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement;  
public class MainMenu: MonoBehaviour {  
    public void PlayGame()
    {
        // Scene Gamescene = SceneManager.GetSceneByName("Gamescene");
        // SceneManager.SetActiveScene(Gamescene);
        var parameters = new LoadSceneParameters(LoadSceneMode.Additive);
        SceneManager.LoadScene("Gamescene", parameters);
    }  
}