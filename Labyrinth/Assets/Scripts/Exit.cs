using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {
    public Player Player = new Player();
    public List<string>inventory = new List<string>();
    private int FullInventory = 5;
    public BoxCollider2D collidingObject;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        inventory = Player.Inventory;
        inventory.Sort();
        if (inventory.Count == FullInventory)
        {
            Destroy(collidingObject);
        }
	}
}
