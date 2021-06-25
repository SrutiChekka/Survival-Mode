using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    WaveUI waveUI;

    public Text currentKillsText;
    public Text currentWaveText;

    // Start is called before the first frame update
    void Start()
    {
        waveUI = FindObjectOfType<WaveUI>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        currentKillsText = WaveUI.FindObjectOfType<WaveUI>().enemyText;
    }
}
