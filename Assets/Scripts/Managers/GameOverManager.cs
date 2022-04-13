using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Text warningText;
    public Text finalScoreText;
    public PlayerHealth playerHealth;
    public ScoreManager scoreManager;
    public EnemyManager enemyManager;

    public Text gameModeText;
    public Text waveTimeText;

    public int maxWave = 12;
 
    Animator anim;

    GameObject playerDataSingleton;
    PlayerData playerData;
 
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        playerDataSingleton = GameObject.FindGameObjectWithTag("Data");
        playerData = playerDataSingleton.GetComponent<PlayerData> ();
    }
 
    void Update()
    {
        if ((playerHealth.currentHealth <= 0) || (enemyManager.currentWaveIdx == maxWave))
        {
            scoreManager.isScoring = false;
            finalScoreText.text = playerData.getPlayerName() + "\'s FINAL SCORE: " + Mathf.RoundToInt(scoreManager.score).ToString();

            if (scoreManager.isZen)
            {
                gameModeText.text = "GAME MODE: ZEN";
                waveTimeText.text = "ELAPSED TIME: " + Mathf.RoundToInt(scoreManager.score).ToString() + " s";
            } else 
            {
                gameModeText.text = "GAME MODE: WAVE";
                waveTimeText.text = "LAST WAVE: " + enemyManager.currentWaveIdx;
            }
            
            anim.SetTrigger("GameOver");
        }
    }
 
    public void ShowWarning(float enemyDistance)
    {
        warningText.text = string.Format("DANGER! {0} m",Mathf.RoundToInt(enemyDistance));
        anim.SetTrigger("Warning");
    }
}