using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    GameObject playerDataSingleton;
    PlayerData playerData;

    public List<ZenScore> zenScoreBoard = new List<ZenScore>();
    public List<WaveScore> waveScoreBoard = new List<WaveScore>();

    public TextMeshProUGUI zenBoard;
    public TextMeshProUGUI waveBoard;

    void Start()
    {
        playerDataSingleton = GameObject.FindGameObjectWithTag("Data");
        playerData = playerDataSingleton.GetComponent<PlayerData> ();

        zenScoreBoard = playerData.getZenScoreBoard();
        waveScoreBoard = playerData.getWaveScoreBoard();

        displayScoreboard();
    }

    private void displayScoreboard()
    {
        zenBoard.text = "";
        waveBoard.text = "";
        int i = 1;

        foreach (var zenScore in zenScoreBoard){
            zenBoard.text += i.ToString() + ". " + zenScore.name + " : " + zenScore.time.ToString() + " seconds\n";
            i += 1;
        }

        i = 1;
        foreach (var waveScore in waveScoreBoard){
            waveBoard.text += i.ToString() + ". " + waveScore.name + " : " + waveScore.score.ToString() + " pts : " + waveScore.maxWaves.ToString() + " waves\n";
            i += 1;
        }
    }
}
