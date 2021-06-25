using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    public Text waveText;
    public Text enemyText;
    public Text killsText;

    public void UpdateUI(int _wave, int _enemies, int _kills)
    {
        waveText.text = "Wave no: " + _wave.ToString();
        enemyText.text = "Enemies Remaining: " + _enemies.ToString();
        killsText.text = "Kills: " + _kills.ToString();
    }

    public void HideUI()
    {
        waveText.text = "";
        enemyText.text = "";
        killsText.text = "";
    }
}
