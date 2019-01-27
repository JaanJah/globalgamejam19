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
    public Image Dog;
    public Image Boy;
    public Image GreenKey;
    public Image PurpleKey;

    public AudioClip GreenDoor;
    public AudioClip PurpleDoor;
   
    void Start ()
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();
        startingColor = new Color32(225, 225, 225, 255);
        //Mom.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
        Dog.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
        Boy.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
        GreenKey.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
        PurpleKey.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
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
                    Mom.GetComponent<Image>().color = startingColor;
                    break;
                case "Dog":
                    Inventory.Add("Dog");
                    CollectedItems.text += "Dog, ";
                    Destroy(collision.gameObject);
                    Dog.GetComponent<Image>().color = startingColor;
                    break;
                case "Green Key":
                    Inventory.Add("Green Key");
                    CollectedItems.text += "Green key, ";
                    Destroy(collision.gameObject);
                    GreenKey.GetComponent<Image>().color = startingColor;
                    break;
                case "Boy":
                    Inventory.Add("Boy");
                    CollectedItems.text += "Boy, ";
                    Destroy(collision.gameObject);
                    
                    break;
                case "Purple Key":
                    Inventory.Add("Purple Key");
                    CollectedItems.text += "Purple Key, ";
                    Destroy(collision.gameObject);
                    PurpleKey.GetComponent<Image>().color = startingColor;
                    break;
                default:
                    Inventory.Add(collision.gameObject.name);
                    CollectedItems.text += collision.gameObject.name;
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
            if (Inventory.Contains("Green Key"))
            {
                Destroy(collision.gameObject);
                gameObject.GetComponent<AudioSource>().PlayOneShot(GreenDoor);
                Inventory.Remove("Green Key");
                CollectedItems.text = Uitext;

            }
        }

        if (collision.gameObject.tag == "PurpleDoor")
        {
            if (Inventory.Contains("Purple Key"))
            {
                Destroy(collision.gameObject);
                gameObject.GetComponent<AudioSource>().PlayOneShot(PurpleDoor);
                Inventory.Remove("Purple Key");
                foreach (var item in Inventory)
                {
                    Uitext += item + ", ";
                }
                CollectedItems.text = Uitext;
            }
        }
    }
}
