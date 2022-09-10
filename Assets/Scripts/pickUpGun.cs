using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpGun : MonoBehaviour {

    private bool pickedUp = false;

    GameObject gunManager;
    void Start() {
        gunManager = GameObject.FindGameObjectWithTag("GunManager");
    }
    
    void OnTriggerStay2D(Collider2D other){
		if (Input.GetKeyDown(KeyCode.E) && other.CompareTag("Player") && !pickedUp) {
            pickedUp = true;
            gameObject.GetComponent<Shooting>().onGround = false;
            gunManager.GetComponent<gunHolder>().addGun(gameObject);
            gameObject.transform.SetParent(gunManager.transform, true);
            gameObject.transform.position = gunManager.transform.position;
        }
	}
}
