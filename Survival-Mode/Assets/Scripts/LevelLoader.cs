using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour
{
    public void LoadStartGame()
    {
        SceneManager.LoadScene(0);
    }
    
    public void GameOver()
    {
        SceneManager.LoadScene(1);
    }
}
