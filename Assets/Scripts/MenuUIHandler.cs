using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI highScoreUI;
    public GameObject startGameButton;
    private PlayerManager playerMNG;
    // Start is called before the first frame update
    void Start()
    {
        playerMNG = PlayerManager.Instance;
        if (highScoreUI.enabled) { highScoreUI.enabled = false; }
        if (startGameButton.activeInHierarchy) { startGameButton.SetActive(false); }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReadyToStart()
    {
        highScoreUI.enabled = true;
        startGameButton.SetActive(true);
        highScoreUI.text = "HighScore: " + playerMNG.highscore.ToString()+" from "+playerMNG.bestPlayer;

    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
}
