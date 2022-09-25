using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;
    public GameObject coin;

    // Start is called before the first frame update
    void Start() {
        currentHealth = maxHealth; 
    }


    public void TakeDamage(int damage) {
        currentHealth -= damage;
        
        if (currentHealth <= 0) {
            Instantiate(coin, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }  
    }

    void spawnLoot() {
        
    }
}
