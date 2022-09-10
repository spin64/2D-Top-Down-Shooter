using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour {

    private RoomTemplates templates;
    public List<GameObject> units;

    public List<GameObject> spawners;
    public GameObject doors;

    bool spawned = false;

    void Start() {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();

        foreach (Transform child in gameObject.transform.parent) {
            if (child.gameObject.tag == "Door"){
                doors = child.gameObject;
                break;
            }
        }  

        doors.SetActive(false);

        foreach (Transform child in gameObject.transform) {
            spawners.Add(child.gameObject);
        }   
    }

    void FixedUpdate(){
        Debug.Log(spawners.Count);
        if (spawned) {
            Invoke("checkForClear", 2f);
        }
    }

    void checkForClear() {
        for (int i = 0; i < units.Count; ++i){
            if (units[i] != null) {
                return;
            }
        }
        doors.SetActive(false);
    }
    
    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player") && !spawned){
            doors.SetActive(true);
            spawned = true;
            spawnMobs();
        }

        if (other.CompareTag("Enemy")) {
            units.Add(other.gameObject);
        }
	}

    void spawnMobs() {
        Debug.Log(templates.enemies.Count);
        for (int i = 0; i < spawners.Count; ++i){
            int rand = Random.Range(0, templates.enemies.Count - 1);
            Instantiate(templates.enemies[rand], spawners[i].transform.position, spawners[i].transform.rotation);
        }   
    }
}
