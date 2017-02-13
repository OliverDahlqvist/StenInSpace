using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyUi : MonoBehaviour {

    
    private bool Inbounds = false;
    public GameObject AirBox; 
    public Slider Energy;
    public Text EnergyPercentage;
    public Text Inventory;
    public int InventoryMax = 50;
    public int CurrentInventory = 0; 
    public int EnergyMax;
    public float EnergyDrain;
    public float EnergyGain; 
    private float CurrentEnergy = 100f; 

    // Use this for initialization
    void Start ()
    {

        Energy.maxValue = EnergyMax;
        Energy.value = EnergyMax;
        EnergyPercentage.text = Energy.value + "%";
        
        
	}

    void OnTriggerEnter(Collider AirBox)
    {
        Inbounds = true; 
    }
    void OnTriggerExit(Collider AirBox)
    {
        Inbounds = false; 
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (!Inbounds)
        {
            CurrentEnergy -= Time.deltaTime / EnergyDrain ;
        }
        else if (Inbounds && Energy.value <= EnergyMax)
        {
            CurrentEnergy += Time.deltaTime / EnergyGain ;
        }
        else
        {

        }
        CurrentInventory = GameObject.Find("MainCamera").GetComponent<MineStone>().stones;
        Inventory.text = CurrentInventory + "/" + InventoryMax;
        Energy.value = CurrentEnergy; 

        EnergyPercentage.text = Energy.value + "%";

    }
}
