using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    public Text waveText;
    public Text enemyText;
    public Text killsText;

    public void UpdateUI(int _wave, int _enemies, int _kills)
    {
        waveText.text = _wave.ToString();
        enemyText.text = _enemies.ToString();
        killsText.text = _kills.ToString();
    }

    public void HideUI()
    {
        waveText.text = "";
        enemyText.text = "";
        killsText.text = "";
    }
}
