using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject zombiePrefab;
    public Text waveText;
    public Animator anim;

    int wave = 1;
    int totalEnemies;
    int enemiesSpawned = 0;

    float spawnWaitTime = 2.8f;
    float spawnMinTime = 0.15f;
    float spawnDecrement = 0.25f;
    float waveCooldown = 0;
    float waveCooldownOrignal = 25;
    bool enemyCanSpawn = true;
    bool showedWave = false;


    // Start is called before the first frame update
    void Start()
    {
        totalEnemies = Random.Range((wave * 10), (wave * 10 + 10));
        waveText.text = "Wave " + 1;
        anim.SetTrigger("ShowWaveNum");
    }

    // Update is called once per frame
    void Update()
    {
        spawnWave();
    }

    void setVariables()
    {
        totalEnemies = Random.Range((wave * 30), (wave * 30 + 10));
        if(spawnWaitTime > spawnMinTime)
        {
            spawnWaitTime -= spawnDecrement;
        }
        wave++;
        waveText.text = "Wave " + wave.ToString();
        anim.SetTrigger("ShowWaveNum");
        Debug.Log(wave);
    }

    void spawnWave()
    {
        if (totalEnemies > enemiesSpawned)
        {
            spawnEnemy();
        }
        else
        {
            if (waveCooldown >= waveCooldownOrignal)
            {
                setVariables();
                waveCooldown = 0;
            }
            else
            {
                waveCooldown += Time.deltaTime;
            }
        }
    }
 
    void spawnEnemy()
    {
        if (enemyCanSpawn == true)
        {
            for (int i = 0; i < Random.Range(1, 4); i++)
            {
                Instantiate(zombiePrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
            }
            StartCoroutine(enemySpawn());

            enemiesSpawned++;
        }
    }

    void showWave()
    {

    }

    IEnumerator enemySpawn()
    {
        enemyCanSpawn = false;
        yield return new WaitForSeconds(spawnWaitTime);
        enemyCanSpawn = true;
    }

    IEnumerator setVariablesCooldown()
    {
        yield return new WaitForSeconds(waveCooldown);
        setVariables();
    }
}
