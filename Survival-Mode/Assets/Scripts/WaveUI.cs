using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    public Text waveText;
    public Text enemyText;
    public Text killsText;
    
    public Text highestWaveText;
    public Text highestKillsText;

    public Text EnterMessage;

    private void Start()
    {
        highestWaveText.text = "Highest Wave: " + PlayerPrefs.GetInt("HighestWave", 0).ToString();
        highestKillsText.text = "Highest Kills: " + PlayerPrefs.GetInt("HighestKills", 0).ToString();
    }

    public void UpdateUI(int _wave, int _enemies, int _kills)
    {
        waveText.text = "Wave no: " + _wave.ToString();
        enemyText.text = "Enemies Remaining: " + _enemies.ToString();
        killsText.text = "Kills: " + _kills.ToString();

        if(_kills > PlayerPrefs.GetInt("HighestKills", 0))
        {
            PlayerPrefs.SetInt("HighestKills", _kills);
            highestKillsText.text = _kills.ToString();
        }

        if (_wave > PlayerPrefs.GetInt("HighestWave", 0))
        {
            PlayerPrefs.SetInt("HighestWave", _wave);
            highestWaveText.text = _wave.ToString();
        }
    }

    public void HideUI()
    {
        waveText.text = "";
        enemyText.text = "";
        killsText.text = "";
    }
}
