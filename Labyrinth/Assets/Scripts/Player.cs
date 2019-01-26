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

    public Color32 startingColor;

    public Image Mom;
   
    void Start ()
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();
        startingColor = new Color32(194, 194, 194, 255);
        Mom.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
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
        string Uitext = "";
        if (collision.gameObject.tag == "ObjectToCollect")
        {
            switch (collision.gameObject.name)
            {
                case "Mom":
                    Inventory.Add("Mom");
                    CollectedItems.text += "Mom\n";
                    Destroy(collision.gameObject);

                    break;
            }
            //Inventory.Add(collision.gameObject.name);
            //foreach (var item in Inventory)
            //{
            //    Uitext += item +", ";
            //}
            //CollectedItems.text = Uitext;
            //Destroy(collision.gameObject);

        }
        if (collision.gameObject.tag == "Door")
        {
            stopwatch.Stop();
            stopwatch.Reset();
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
    }
}
