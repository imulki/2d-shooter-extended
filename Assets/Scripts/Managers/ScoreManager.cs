using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public float score;

    public bool isZen = true;
    public bool isScoring = true;


    Text text;


    void Awake ()
    {
        text = GetComponent <Text> ();
        if (isZen)
        {
            score = 1;
        } else 
        {
            score = 0;
        }        
    }


    void Update ()
    {
        text.text = "Score: " + ((int)score);

        if (isZen && isScoring)
        {
            score += Time.deltaTime;
        }
    }

    public void AddScore (int delta) 
    {
        if (!isZen)
        {
            score += delta;
        }
    }
}
