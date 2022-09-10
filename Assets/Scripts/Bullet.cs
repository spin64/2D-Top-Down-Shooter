using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 3f;
    public int damage = 10;
    public Rigidbody2D rb;

    void Start() {
        rb.velocity = transform.right * speed/5;
        Physics2D.IgnoreLayerCollision(6, 7, true);
        Physics2D.IgnoreLayerCollision(7, 9, true);
    }

    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "Wall"){
            Destroy(gameObject);
        }     

        if (other.gameObject.tag == "Enemy" && gameObject.layer == 6) {
            if (other != null) {
                other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }

        if (other.gameObject.tag == "Player" && gameObject.layer == 7){
           if (other != null) {
                other.gameObject.GetComponent<playerHealth>().TakeDamage(damage);
                Destroy(gameObject);
            } 
        }
    }


}


