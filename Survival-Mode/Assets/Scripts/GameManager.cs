using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private WaveManager waveManager;
    private ThirdPersonController player;

    public bool gameOver = false;

    private void Start()
    {
        waveManager = GetComponent<WaveManager>();
        player = FindObjectOfType<ThirdPersonController>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1;
            waveManager.StartWave();
        }

        if (!player)
        {
            gameOver = true;
            Time.timeScale = 0;
            Debug.Log("/---------Game Over-----------/");
        }
    }
}
