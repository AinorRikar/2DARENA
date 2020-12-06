using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public GameObject scoreLable;
    public GameObject dieLable;
    public int startScore;

    private int score;
    private int waveN;
    private int enemies;

    void Start()
    {
        score = startScore;
        waveN = 0;
        enemies = 0;
        Enemy.EnemyDieEvent += addScore;
        WaveSpawner.WaveStartEvent += getWave;
        PlayerController.PlayerDieEvent += onPlayerDied;
        //EventAggregator.DamageableObjectDied.Subscribe(addScore);
    }

    void Update()
    {
        scoreLable.GetComponent<Text>().text = "Score: " + score.ToString() + " Wave: " + waveN.ToString() + " Enemies: " + enemies.ToString();
    }

    void addScore(int dif)
    {
        score += dif;
    }

    void getWave(int w, int e)
    {
        waveN = w;
        enemies = e;
    }

    void onPlayerDied()
    {
        dieLable.GetComponent<Text>().text = "YOU'VE DIED!";
    }
}
