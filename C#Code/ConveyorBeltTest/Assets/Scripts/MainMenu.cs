using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement;  
public class MainMenu: MonoBehaviour {  
    public void PlayGame()
    {
        var parameters = new LoadSceneParameters(LoadSceneMode.Additive);
        SceneManager.LoadScene("Gamescene", parameters);
    }  
}