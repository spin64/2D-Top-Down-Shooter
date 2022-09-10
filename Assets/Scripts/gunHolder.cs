using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gunHolder : MonoBehaviour {
    int totalGuns = 1;
    public int curGunIndex = 0;

    public List<GameObject> guns;
    public GameObject currentGun;

    public Text ammoDisplay;
    public Text reserveDisplay;

    // Start is called before the first frame update
    void Start() {
        totalGuns = gameObject.transform.childCount;

        for (int i = 0; i < totalGuns; ++i) {
            guns.Add(gameObject.transform.GetChild(i).gameObject);
            guns[i].SetActive(false);
        }
        guns[0].SetActive(true);
        currentGun = guns[0];
        curGunIndex = 0;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f){
            guns[curGunIndex].SetActive(false);
            ++curGunIndex;
            if (curGunIndex > totalGuns - 1){
                curGunIndex = 0;
            }
            guns[curGunIndex].SetActive(true);
            currentGun =  guns[curGunIndex];
        } else if (Input.GetAxis("Mouse ScrollWheel") < 0f) {
            guns[curGunIndex].SetActive(false);
            --curGunIndex;
            if (curGunIndex < 0){
                curGunIndex = totalGuns - 1;
            }
            guns[curGunIndex].SetActive(true);
            currentGun =  guns[curGunIndex];
        }

        ammoDisplay.text = guns[curGunIndex].GetComponent<Shooting>().ammo.ToString();
        reserveDisplay.text = guns[curGunIndex].GetComponent<Shooting>().reserveAmmo.ToString();
    }

    public void addGun(GameObject newGun){
        guns.Add(newGun);
        ++totalGuns;
        guns[curGunIndex].SetActive(false);
        curGunIndex = totalGuns - 1;
        guns[curGunIndex].SetActive(true);
    }
}
