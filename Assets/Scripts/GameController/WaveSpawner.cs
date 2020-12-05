using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject[] units;
    public int startCount;
    public float waveMod;
    public int wavePause;

    private GameObject[] wave;
    private int waveN;
    private float waveCount;

    private float timer;

    private void Start()
    {
        waveN = 0;
        waveCount = startCount;
    }

    private void Update()
    {
        GameObject[] list = GameObject.FindGameObjectsWithTag("Enemy");
        
        if(list.Length <= 0)
        {
            if (timer <= 0)
            {
                timer = wavePause;
                for (int i = 0; i < Mathf.RoundToInt(waveCount); i++)
                {
                    Spawn();
                }
                waveN++;
                waveCount = waveCount * waveMod;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
        
    }

    private void Spawn()
    {
        Vector2 spawnPoint;
        spawnPoint.x = Random.Range(-9f, 9f);
        spawnPoint.y = Random.Range(-9f, 9f);
        //Mathf.RoundToInt(Random.Range(0, units.Length))
        Instantiate(units[0], spawnPoint, Quaternion.identity);
    }
}
