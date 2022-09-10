using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public SpriteRenderer spriteRenderer;
    public float speed = 1f;
    public Rigidbody2D rb;
    private Transform player;
    private Vector3 movement;
    public bool boss = false;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update() {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;

        spriteRenderer.flipX = direction.x < 0;
    }

    public void FixedUpdate() {
        moveCharacter(movement);
    }
    
    void moveCharacter(Vector3 direction) {
        Vector3 dist = player.position - transform.position;
        if (dist.magnitude >= 5 && !boss) {
            rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));  
        }  

        if (boss && dist.magnitude <= 1){
            rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));  
        }
    }   
}