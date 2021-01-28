using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
     private int Score;

    [SerializeField] private Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "Score: "+Score;
    }

    void IncrementScore()
    {
        Score = Score + 1;

    }
}
