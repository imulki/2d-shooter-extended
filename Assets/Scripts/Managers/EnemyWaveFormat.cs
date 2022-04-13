using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyWaveFormat
{
    public int waveWeight;
    public int[] enemyIdxList;

    public EnemyWaveFormat(int _waveWeight, int[] _enemyIdxList)
    {
        waveWeight = _waveWeight;
        enemyIdxList = _enemyIdxList;
    }
}
