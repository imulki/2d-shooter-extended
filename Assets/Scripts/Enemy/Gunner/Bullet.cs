using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int attackDamage = 5;
    public float lifetime = 10f;
    public float speed = 5f;

    PlayerHealth playerHealth;
    private Vector3 direction;

    void Update ()
    {
        transform.position += direction * Time.deltaTime * speed;

        lifetime -= Time.deltaTime;
        if (lifetime <= 0) {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        //Set player dalam range
        
        if(!other.isTrigger && other.gameObject.tag == "Player")
        {
            playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(attackDamage);
            Destroy(gameObject);
        }
    }
    
    public void Setup(Vector3 direction)
    {
        this.direction = direction;
    }
}
