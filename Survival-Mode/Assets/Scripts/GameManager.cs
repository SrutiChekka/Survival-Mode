using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Canvas gameOverCanvas;

    private WaveManager waveManager;
    private ThirdPersonController player;

    public bool gameOver = false;

    private void Start()
    {
        waveManager = GetComponent<WaveManager>();
        player = FindObjectOfType<ThirdPersonController>();

        gameOverCanvas.gameObject.SetActive(false);

    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            FindObjectOfType<WaveUI>().EnterMessage.gameObject.SetActive(false);
            Time.timeScale = 1;
            waveManager.StartWave();
        }

        if (!player)
        {
            Time.timeScale = 0;
            gameOver = true;
            gameOverCanvas.gameObject.SetActive(true);
        }
    }
}
