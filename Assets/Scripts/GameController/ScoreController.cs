using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public GameObject scoreLable;
    public int startScore;

    private int score;

    void Start()
    {
        score = startScore;
        EventAggregator.DamageableObjectDied.Subscribe(addScore);
    }

    void Update()
    {
        scoreLable.GetComponent<Text>().text = "Score: " + score.ToString();
    }

    void addScore(DamageableObject obj)
    {
        score++;
    }
}
