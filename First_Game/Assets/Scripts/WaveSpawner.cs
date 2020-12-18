using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[System.Serializable]

public class Wave
{
    public string name; //name of wave
    public int numberEnemy; //number of enemies in the wave
    public GameObject[] enemies; //type of enemies in the wave
    public float spawnInterval; //spawn interval
}
public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves; //array of all the waves
    public Transform[] spawnpoints; //spawn locations
    public Text waveName;

    private Wave currentwave;
    private int currentwavenumber=0;
    private float nextSpawnTime;

    private bool canSpawn =true;

    private void Update()
    {
        currentwave = waves[currentwavenumber];
        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (totalEnemies.Length == 0 && !canSpawn && currentwavenumber + 1 != waves.Length)
        {
            currentwavenumber++;
            canSpawn = true;
        }
        waveName.text = waves[currentwavenumber].name;

        if (totalEnemies.Length == 0 && !canSpawn && currentwavenumber + 1 == waves.Length)
        {
            SceneManager.LoadScene("Victory");
        }
    }

    void SpawnWave()
    {
        if(canSpawn && nextSpawnTime < Time.time)
        {
            Transform randompoint;
            GameObject randomenemy = currentwave.enemies[Random.Range(0, currentwave.enemies.Length)]; //gets a random enemy rocket/slime/zombie

            if (randomenemy.name == "Rocket") //if random enemy is rocket spawn in sky
            {
                randompoint = spawnpoints[0];
            }
            else
            {
                randompoint = spawnpoints[1]; //else spawn on ground
            }

            Instantiate(randomenemy, randompoint.position, Quaternion.identity); //spawn the enemy
            currentwave.numberEnemy--;
            nextSpawnTime = Time.time + currentwave.spawnInterval;
            if(currentwave.numberEnemy == 0)
            {
                canSpawn = false;
            }
        }
            
    }
}
