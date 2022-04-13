using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform shootStart;

    Animator anim;
    bool playerInRange;
    float timer;
    GameObject player;
    EnemyHealth enemyHealth;
    PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        anim = GetComponent <Animator> ();
        enemyHealth = GetComponent<EnemyHealth>();  
    }

    //Callback jika ada suatu object masuk kedalam trigger
    void OnTriggerEnter (Collider other)
    {
        //Set player dalam range
        if(other.gameObject == player && other.isTrigger == false)
        {
            playerInRange = true;
        }
    }
 
    //Callback jika ada object yang keluar dari trigger
    void OnTriggerExit (Collider other)
    {
        //Set player jika tidak dalam range
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
 
        if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack ();
        }
 
        //mentrigger animasi PlayerDead jika darah player kurang dari sama dengan 0
        if(playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger ("PlayerDead");
        }
    }

    void Attack ()
    {
        //Reset timer
        timer = 0f;
 
        //Taking Damage
        if(playerHealth.currentHealth > 0)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootStart.position, Quaternion.identity);

        Vector3 playerPos = player.transform.position;
        playerPos.y += 1;

        Vector3 shootDirection = (playerPos - shootStart.position).normalized;
        bullet.GetComponent<Bullet>().Setup(shootDirection);
    }
    
}
