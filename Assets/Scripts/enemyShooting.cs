using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShooting : MonoBehaviour {
    Camera mainCam;
    Vector3 mousePos;
    public Transform attackPoint;
    public GameObject bulletPrefab;
    public SpriteRenderer spriteRender;

    // general for different guns
    float nextShotTime = 0;
    public bool shotgun = false;
    bool shooting = true;

    // gun specific
    int ammo = 30;
    public int maxCapcity = 30;
    public float fireRate = 2f;
    public float spread = 0.2f;

    // player stuff
    private Transform player;
    private Vector3 movement;
    
    // Start is called before the first frame update
    void Start() {
        Reload();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() {

        // gun follows player
        Vector3 toPlayer = player.position - transform.position;
        float rotZ = Mathf.Atan2(toPlayer.y, toPlayer.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f,0f,rotZ);

        // rotate gun sprite for orientation
        if (rotZ < 89 && rotZ > -89){
            spriteRender.flipY = false;
        } else {
            spriteRender.flipY = true;
        }

        // fixed firerate
        if (Time.time >= nextShotTime) {
            if (ammo > 0){
                if (toPlayer.magnitude <= 10 && shooting){
                    Shoot();
                }
            } else {
                Debug.Log("empty");
                shooting = false;
                Invoke("Reload", 2.0f);
            }
            nextShotTime = Time.time + 1f / fireRate;
        }  
    }

    void Shoot() {
        int shots = 1;

        if (shotgun){
            shots = Random.Range(0,10);
        }

        for (int i = 0; i < shots; ++i){
            GameObject bullet = Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
            bullet.transform.Rotate(0, 0, Random.Range(-spread,spread));
        }
        
        --ammo;
    }

    void Reload() {
        ammo = maxCapcity;
        shooting = true;
        Debug.Log("reloaded");
    }
}
