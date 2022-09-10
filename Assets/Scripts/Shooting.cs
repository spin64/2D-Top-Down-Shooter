using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
    
    Camera mainCam;
    Vector3 mousePos;
    public Transform attackPoint;
    public GameObject bulletPrefab;
    public SpriteRenderer spriteRender;

    // general for different guns
    float nextShotTime = 0;
    bool reloading = false;
    public bool shotgun = false;
    public bool shooting = true;

    // gun specific
    public int ammo = 30;
    public int maxCapcity = 30;
    public int reserveAmmo = 900;
    public int reserveMax = 900;
    public float fireRate = 2f;
    public float spread = 0.2f;
    public float reloadTime = 2.0f;

    public bool onGround = true;
    
    // Start is called before the first frame update
    void Start() {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        ammo = maxCapcity;
        reserveAmmo = reserveMax;
    }

    // Update is called once per frame
    void Update() {

        if (!onGround){
            // gun follows mouse
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 rotation = mousePos - transform.position;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
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
                    if (Input.GetMouseButton(0) && shooting) {
                        Shoot();
                    }
                } else {
                    Debug.Log("empty");
                    reloading = true;
                    shooting = false;
                    Invoke("Reload", 2.0f);
                }
                
                nextShotTime = Time.time + 1f / fireRate;
            }  

            // call reload
            if (Input.GetKeyDown(KeyCode.R) && !reloading){
                reloading = true;
                shooting = false;

                if (shotgun) {
                    for (int i = ammo; i < maxCapcity; ++i) {
                        Invoke("Reload", reloadTime);  
                    }
                } else {
                    Invoke("Reload", reloadTime);   
                }
                
            }
        }    
    }

    void Shoot() {
        int shots = 1;

        if (shotgun){
            shots = 10;
        }

        for (int i = 0; i < shots; ++i){
            GameObject bullet = Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
            bullet.transform.Rotate(0, 0, Random.Range(-spread,spread));
        }
        
        --ammo;
    }

    void Reload() {
        if (reserveAmmo - 1 < 0 || reserveAmmo - (maxCapcity - ammo) < 0) {
            Debug.Log("Out of ammo");
            return;
        }

        if (shotgun) {
            --reserveAmmo;
            ++ammo;
        } else {
            reserveAmmo -= (maxCapcity - ammo);
            ammo = maxCapcity;
        }
        
        reloading = false;
        shooting = true;
        Debug.Log("reloaded");
        
    }
}
