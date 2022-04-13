using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour, IFactory{

    [SerializeField]
    public GameObject[] enemyPrefab;
    public int[] enemyWeight;

    public GameObject bossPrefab;

    public GameObject FactoryMethod(int tag)
    {
        GameObject enemy = Instantiate(enemyPrefab[tag]);
        return enemy;
    }

    public GameObject[] RandomMassFactoryMethod(int value, int[] tag, string specialCase)
    {
        List<GameObject> enemyList = new List<GameObject>();

        while (value > 0)
        {
            int idx = Random.Range(0, tag.Length);
            GameObject enemy = Instantiate(enemyPrefab[idx]);
            enemyList.Add(enemy);

            value -= enemyWeight[idx];
        }

        if (specialCase == "boss")
        {
            GameObject boss = Instantiate(bossPrefab);
            enemyList.Add(boss);
        }
        
        return enemyList.ToArray();
    }
}