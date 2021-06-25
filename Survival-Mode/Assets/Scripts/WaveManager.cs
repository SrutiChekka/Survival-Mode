using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(GameManager))]
[RequireComponent(typeof(Timer))]
[RequireComponent(typeof(WaveUI))]
public class WaveManager : MonoBehaviour
{
    private int currentWave = 0;
    private int enemiesInWave;
    private int enemiestoSpawn;
    private int enemiesKilled = 0;

    private WaveUI ui;

    private Timer timer;

    private GameManager manager;

    private List<Transform> spawners = new List<Transform>();

    public float spawnDelay;

    public float roundDelay;

    public int enemyIncreaseFactor;

    public GameObject enemy;

    public GameObject extraLife;
    public Transform extraLifePos;


    private void Start()
    {
        manager = GetComponent<GameManager>();
        timer = GetComponent<Timer>();
        ui = GetComponent<WaveUI>();

        ui.HideUI();

        foreach(Transform child in transform)
        {
            spawners.Add(child);
        }
    }

    public void StartWave()
    {
        if (manager.gameOver)
        {
            return;
        }

        currentWave += 1;

        Instantiate(extraLife, extraLifePos);

        enemiesInWave = enemyIncreaseFactor * currentWave;
        enemiestoSpawn = enemiesInWave;

        ui.UpdateUI(currentWave, enemiesInWave, enemiesKilled);

        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < enemiestoSpawn; i++)
        {
            if (manager.gameOver)
            {
                break;
            }

            Instantiate(enemy, GetRandomSpawner(), Quaternion.identity);

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void EndWave()
    {
        ui.HideUI();
        timer.StartTimer(roundDelay);
    }

    public void EnemyDied()
    {
        enemiesInWave -= 1;
        enemiesKilled++;

        ui.UpdateUI(currentWave, enemiesInWave, enemiesKilled);

        if (enemiesInWave == 0)
        {
            EndWave();
        }
    }

    public Vector3 GetRandomSpawner()
    {
        return spawners[Random.Range(0, spawners.Count)].position;
    }
}
