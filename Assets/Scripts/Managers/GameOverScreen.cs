using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen: MonoBehaviour
{
    PlayerData playerData;
    ScoreManager scoreManager;
    EnemyManager enemyManager;
    
    void Start()
    {
        playerData = GameObject.FindGameObjectWithTag("Data").GetComponent<PlayerData>();
        scoreManager = GameObject.FindGameObjectWithTag("HUD").GetComponent<ScoreManager>();
        enemyManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemyManager>();
    }

    public void RestartLevel ()
    {
        Debug.Log("RESTART TRIGGERED");
        //meload ulang scene dengan index 0 pada build setting
        SceneManager.LoadScene (SceneManager.GetActiveScene().name);
    }

    public void BackToMainMenu ()
    {
        SendData();
        SceneManager.LoadScene("MainMenu");
    }

    void SendData()
    {
        if (scoreManager.isZen)
        {
            ZenScore data = new ZenScore();
            data.name = playerData.getPlayerName();
            data.time = Mathf.RoundToInt(scoreManager.score);
            playerData.addZenScoreBoard(data);
        }
        else
        {
            WaveScore data = new WaveScore();
            data.name = playerData.getPlayerName();
            data.score = Mathf.RoundToInt(scoreManager.score);
            data.maxWaves = enemyManager.currentWaveIdx;
            playerData.addWaveScoreBoard(data);
        }
    }
}
