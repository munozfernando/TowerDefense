using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 1f;
    public float countdown = 2f;
    public Text waveCountdownText;

    private int waveNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
        }
        countdown -= Time.deltaTime;
        waveCountdownText.text = countdown.ToString("0");
    }

    IEnumerator SpawnWave()
    {
        countdown = timeBetweenWaves;
        waveNumber++;

        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.25f);
        }
        
        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
