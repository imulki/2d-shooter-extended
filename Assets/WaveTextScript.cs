using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveTextScript : MonoBehaviour
{
    public EnemyManager enemyManager;

     Text waveText;

    // Start is called before the first frame update
    void Start()
    {
        waveText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        waveText.text = "WAVE: " + enemyManager.currentWaveIdx.ToString();
    }
}
