using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public List<string> Inventory = new List<string>();
    public Text CollectedItems;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string Uitext = "";
        if (collision.gameObject.tag == "ObjectToCollect")
        {
            Inventory.Add(collision.gameObject.name);
            
            foreach (var item in Inventory)
            {
                Uitext += item +", ";
            }
            CollectedItems.text = Uitext;
            Destroy(collision.gameObject);
            
        }

        if (collision.gameObject.tag == "GreenDoor")
        {
            if (Inventory.Contains("greenKey"))
            {
                Destroy(collision.gameObject);
                Inventory.Remove("greenKey");
                foreach (var item in Inventory)
                {
                    Uitext += item + ", ";
                }
                CollectedItems.text = Uitext;
            }
        }

        if (collision.gameObject.tag == "PurpleDoor")
        {
            if (Inventory.Contains("purpleKey"))
            {
                Destroy(collision.gameObject);
                Inventory.Remove("purpleKey");
                foreach (var item in Inventory)
                {
                    Uitext += item + ", ";
                }
                CollectedItems.text = Uitext;
            }
        }
        //foreach (var item in Inventory)
        //{
        //    if (item == "purpleKey" && collision.gameObject.name == "purpleDoor" ||
        //        item == "greenKey" && collision.gameObject.name == "greenDoor")
        //    {
        //        Inventory.Remove(item);
        //        foreach (var item2 in Inventory)
        //        {
        //            Uitext += item2 + ", ";
        //        }
        //        Destroy(collision.gameObject);
        //        //TODO: Remove the items from CollectedItems.text when this if statement occurs
        //    }
        //}
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	}
}
