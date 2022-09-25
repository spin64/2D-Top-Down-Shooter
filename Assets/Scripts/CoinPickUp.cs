using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour {

    public float speed = 1f;
    public Rigidbody2D rb;
    private Transform player;
    private Vector3 movement;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update() {
        Vector3 dist = player.position - transform.position;
        rb.MovePosition(transform.position + (dist * speed * Time.deltaTime));  
    }


    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            other.GetComponent<PlayerInventory>().updateGold(100);
            Destroy(gameObject);
        }
    }
}
