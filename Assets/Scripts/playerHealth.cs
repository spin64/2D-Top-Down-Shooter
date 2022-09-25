using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public bool invincibility = false;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start() {
        currentHealth = maxHealth; 
        healthBar.SetMaxHealth(maxHealth);
    }


    public void TakeDamage(int damage) {
        if (!invincibility){
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
        
        if (currentHealth <= 0) {
            Destroy(gameObject);
        }  
    }
}
