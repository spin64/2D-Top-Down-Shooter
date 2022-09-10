using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour {

    public int gold = 0;
    public Text goldDisplay;

    void Update(){
        goldDisplay.text = gold.ToString();

    }

    public void updateGold(int amount){
        gold += amount;
    }

}
