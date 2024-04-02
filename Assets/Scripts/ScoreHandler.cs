using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreHandler : MonoBehaviour
{
    
    public Text highScoreText;
    public int currentHighScore;
    public PlayerManager playerMNG;
    
    // Start is called before the first frame update
    void Start()
    {
        playerMNG = PlayerManager.Instance;
        highScoreText.text = "Best Score : " + playerMNG.bestPlayer + " : " + playerMNG.highscore;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerStrikes(int newHighScore)
    {
        playerMNG.highscore = newHighScore;
        playerMNG.bestPlayer = playerMNG.currentPlayer;
        highScoreText.text = "Best Score : " + playerMNG.bestPlayer + " : " + newHighScore;


    }
}
