using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScriptLeft : MonoBehaviour
{
    public static int scoreValueLeft = 0;
    Text leftScore;
    // Start is called before the first frame update
    void Start()
    {
        leftScore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        leftScore.text = "Score A: " + scoreValueLeft;
    }
}
