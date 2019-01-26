using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public List<string> Inventory = new List<string>();
    public Text CollectedItems;
    public Text TimeElapsed;
    public Stopwatch stopwatch;

    // Use this for initialization
    void Start ()
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();
	}
	
	// Update is called once per frame
	void Update ()
    {        
        if (stopwatch.IsRunning == true)
        {
            var ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            TimeElapsed.text = elapsedTime;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ObjectToCollect")
        {
            Inventory.Add(collision.gameObject.name);
            CollectedItems.text += collision.gameObject.name;
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.tag == "Door")
        {
            stopwatch.Stop();
            stopwatch.Reset();
        }

        foreach (var item in Inventory)
        {
            if (item == "purpleKey" && collision.gameObject.name == "purpleDoor" ||
                item == "greenKey" && collision.gameObject.name == "greenDoor")
            {
                Destroy(collision.gameObject);
                Inventory.Remove(item);
                //TODO: Remove the items from CollectedItems.text when this if statement occurs
            }
        }

        foreach (var item in Inventory)
        {
            if (item == "purpleKey" && collision.gameObject.name == "purpleDoor" ||
                item == "greenKey" && collision.gameObject.name == "greenDoor")
            {
                Destroy(collision.gameObject);
                Inventory.Remove(item);
                //TODO: Remove the items from CollectedItems.text when this if statement occurs
            }
        }
    }
}
