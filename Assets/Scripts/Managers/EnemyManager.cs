using UnityEngine;

public class EnemyManager : MonoBehaviour{
    public PlayerHealth playerHealth;
    public float spawnTime = 20f;
    public Transform[] spawnPoints;
    public bool isZen = true;
    public int zenUpgradeInterval = 30;
    public TextAsset enemyWaveText;
    public float waveSpawnInterval = 1f;
    public WeaponUpgradeManager weaponUpgradeManager;
    public ScoreManager scoreManager;
    public int maxWave = 3;

    // Zen Incremental Difficulty;
    public int zenLevel = 1; 
    public int difficultyLevel = 2;
    public int totalEnemies;

    // RELATED FOR WAVE LEVEL
    public int currentWaveIdx;
    int currentEnemyIdx;
    EnemyWaveFormat[] enemyWaveFormat;
    GameObject[] currentEnemyList;
    // END RELATED

    [SerializeField]
    MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }

    void Start(){
        //Mengeksekusi fungs Spawn setiap beberapa detik sesui dengan nilai spawnTime
        if (isZen)
        {
            InvokeRepeating("SpawnRandom", 1, spawnTime);
            return;
        }

        ReadEnemyWaveJson(enemyWaveText);
        currentWaveIdx = 0;
        SpawnWave();
    }

    void Update() 
    {
        if (isZen) 
        {
            int time = Mathf.FloorToInt(scoreManager.score);
            if (Mathf.FloorToInt(time) % zenUpgradeInterval == 0)
            {
                if (!weaponUpgradeManager.gameObject.activeSelf)
                {
                    Time.timeScale = 0;
                    weaponUpgradeManager.gameObject.SetActive(true);
                } else if (weaponUpgradeManager.isUpgradeChosen)
                {
                    scoreManager.score += 1;
                    Time.timeScale = 1;
                    weaponUpgradeManager.isUpgradeChosen = false;
                    weaponUpgradeManager.gameObject.SetActive(false);
                    zenLevel += 1;
                }
                
            }
        }

        else 
        {
            int remainingEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
            if ((remainingEnemy <= 0))
            {
                if (((currentWaveIdx % 3) == 0) && (currentWaveIdx != 0) )
                {
                    if (!weaponUpgradeManager.gameObject.activeSelf)
                    {
                        Time.timeScale = 0;
                        weaponUpgradeManager.gameObject.SetActive(true);
                    } else if (weaponUpgradeManager.isUpgradeChosen)
                    {
                        Time.timeScale = 1;
                        weaponUpgradeManager.isUpgradeChosen = false;
                        weaponUpgradeManager.gameObject.SetActive(false);
                        SpawnWave();
                    }
                } else
                {
                    SpawnWave();
                }

                
            }
        }
        
    }

    void SpawnRandom(){

        int remainingEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
        //Jika player telah mati maka tidak membuat enemy baru
        if (playerHealth.currentHealth <= 0f){
           return;
        }

        if(remainingEnemy >= 70){
            return;
        }

    //     //Mendapatkan nilai random
    //    int spawnPointIndex = Random.Range(0, spawnPoints.Length);
    //    int spawnEnemy = Random.Range(0, 3);

    //     //Memduplikasi enemy
    //     GameObject enemy = Factory.FactoryMethod(spawnEnemy);
    //     enemy.GetComponent<Transform>().Translate(spawnPoints[spawnPointIndex].position);

        int[] enemyTags = new int[]{0,1,2,3, 4};
        string specialCase = "";
        if (zenLevel % 5 == 0)
        {
            specialCase = "boss";
        }

        currentEnemyList = Factory.RandomMassFactoryMethod(zenLevel*difficultyLevel, enemyTags, specialCase);
        for (int i=0; i<currentEnemyList.Length; i++)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            currentEnemyList[i].SetActive(true);
            currentEnemyList[i].GetComponent<Transform>().Translate(spawnPoints[spawnPointIndex].position);
            if (i==0)
            {
                SpawnWaveEnemy();
            }
        }
    }

    void SpawnWave() 
    {
        currentEnemyIdx =0;
        int waveFormatIdx = currentWaveIdx % enemyWaveFormat.Length;

        int lastWaveIdx = enemyWaveFormat.Length - 1;
        int waveWeightAddition = 
            Mathf.FloorToInt((currentWaveIdx / enemyWaveFormat.Length)) * 
            enemyWaveFormat[lastWaveIdx].waveWeight;

        string specialCase = "";
        if (currentWaveIdx % 3 == 2)
        {
            specialCase = "boss";
        }

        EnemyWaveFormat currentWave = enemyWaveFormat[waveFormatIdx];
        currentEnemyList = Factory.RandomMassFactoryMethod(currentWave.waveWeight + waveWeightAddition, currentWave.enemyIdxList, specialCase);

        // foreach(GameObject enemy in currentEnemyList)
        for (int i=0; i<currentEnemyList.Length; i++)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            currentEnemyList[i].SetActive(false);
            currentEnemyList[i].GetComponent<Transform>().Translate(spawnPoints[spawnPointIndex].position);
            if (i==0)
            {
                SpawnWaveEnemy();
            } else 
            {
                Invoke("SpawnWaveEnemy", waveSpawnInterval*i);
            }
        }

        currentWaveIdx = (currentWaveIdx + 1);
    }

    void SpawnWaveEnemy() 
    {
        GameObject enemy = currentEnemyList[currentEnemyIdx];
        enemy.SetActive(true);
        
        // Debug.Log(currentEnemyIdx);

        currentEnemyIdx = (currentEnemyIdx + 1) % currentEnemyList.Length;
    }

    void ReadEnemyWaveJson (TextAsset asset)
    {
        WaveFormatList waveFormatList = JsonUtility.FromJson<WaveFormatList>(asset.text);
        enemyWaveFormat = waveFormatList.waveFormatList;
    }


    [System.Serializable]
    class WaveFormatList
    {
        public EnemyWaveFormat[] waveFormatList;
    }
}
