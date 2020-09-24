using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScriptRight : MonoBehaviour
{
    public static int scoreValueRight = 0;
    Text rightScore;
    // Start is called before the first frame update
    void Start()
    {
        rightScore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        rightScore.text = "Score B: " + scoreValueRight;
    }
}
