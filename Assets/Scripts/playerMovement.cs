using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
    public Rigidbody2D rb;
    public float moveSpeed;
    private float activeMoveSpeed;

    public float dashLength = 0.25f;
    public float dashCD = 1f;

    private float dashCounter;
    private float dashCDCounter;

    public SpriteRenderer spriteRenderer;

    GameObject gun;

    void Start() {
        activeMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update() {
        gun = GameObject.FindGameObjectWithTag("GunManager").GetComponent<gunHolder>().currentGun;

        spriteRenderer.flipX = gun.GetComponent<Shooting>().spriteRender.flipY;

        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * activeMoveSpeed;  

        if (Input.GetMouseButton(1)) {
            if (dashCounter <= 0 && dashCDCounter <= 0) {
                activeMoveSpeed *= 3;
                dashCounter = dashLength;
                Debug.Log("invincible");
                gameObject.GetComponent<playerHealth>().invincibility = true;
                gun.GetComponent<Shooting>().shooting = false;
            }
        }

        if (dashCounter > 0) {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0) {
                activeMoveSpeed = moveSpeed;
                dashCDCounter = dashCD;
                Debug.Log("not invincible");
                gameObject.GetComponent<playerHealth>().invincibility = false;
                gun.GetComponent<Shooting>().shooting = true;
            }
        }

        // cd for dashing
        if (dashCDCounter > 0){
            dashCDCounter -= Time.deltaTime;
        }
    }
}
