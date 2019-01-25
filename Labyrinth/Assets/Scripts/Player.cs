using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public List<string> Inventory = new List<string>();
    public Text CollectedItems;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ObjectToCollect")
        {
            Inventory.Add(collision.gameObject.name);
            CollectedItems.text += collision.gameObject.name+", ";
            Destroy(collision.gameObject);
            
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
