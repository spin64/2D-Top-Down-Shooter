using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour {

	public GameObject[] bottomRooms;
	public GameObject[] topRooms;
	public GameObject[] leftRooms;
	public GameObject[] rightRooms;

	public List<GameObject> enemies;

	public GameObject closedRoom;

	public List<GameObject> rooms;

	private float waitTime = 4f;
	private bool spawnedBoss;
	public GameObject boss;

	void Update(){

		if(waitTime <= 0 && spawnedBoss == false){
			spawnedBoss = true;
			Instantiate(boss, rooms[rooms.Count-1].transform.position, Quaternion.identity);
		} else {
			waitTime -= Time.deltaTime;
		}
	}
}
