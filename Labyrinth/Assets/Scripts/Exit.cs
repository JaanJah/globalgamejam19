using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {
    public Player Player = new Player();
    public List<string>inventory = new List<string>();
    public bool IsOpen = false;
    private int FullInventory = 5;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        inventory = Player.Inventory;
        inventory.Sort();
        if (inventory.Count == FullInventory)
        {
            IsOpen = true;
        }
	}
}
