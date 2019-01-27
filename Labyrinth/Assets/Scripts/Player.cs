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

    public UnityEngine.Object Character;


    public Color32 startingColor;

    public Image Mom;
    public Image Dog;
    public Image Boy;
    public Image GreenKey;
    public Image PurpleKey;
    public Image Girl;
    public Image Phone;

    public AudioClip GreenDoor;
    public AudioClip PurpleDoor;
    public AudioClip Pickup;
   
    void Start ()
    {
        startingColor = new Color32(194, 194, 194, 255);
        Mom.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
        Dog.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
        Boy.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
        GreenKey.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
        PurpleKey.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
        Girl.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
        Phone.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
    }
	

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string Uitext = "";
        if (collision.gameObject.tag == "ObjectToCollect")
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(Pickup);
            switch (collision.gameObject.name)
            {
                case "Woman":
                    Inventory.Add("Woman");
                    CollectedItems.text += "Woman\n";
                    Destroy(collision.gameObject);
                    Mom.GetComponent<Image>().color = startingColor;
                    break;
                case "GameOver":
                    Destroy(gameObject);
                    break;
                case "Dog":
                    Inventory.Add("Dog");
                    CollectedItems.text += "Dog, ";
                    Destroy(collision.gameObject);
                    Dog.GetComponent<Image>().color = startingColor;
                    break;
                case "Baby":
                    Inventory.Add("Baby");
                    CollectedItems.text += "Baby, ";
                    Destroy(collision.gameObject);
                    Boy.GetComponent<Image>().color = startingColor;
                    break;
                case "Green Key":
                    Inventory.Add("Green Key");
                    CollectedItems.text += "Green key, ";
                    Destroy(collision.gameObject);
                    GreenKey.GetComponent<Image>().color = startingColor;
                    break;
                case "Purple Key":
                    Inventory.Add("Purple Key");
                    CollectedItems.text += "Purple Key, ";
                    Destroy(collision.gameObject);
                    PurpleKey.GetComponent<Image>().color = startingColor;
                    break;
                case "Girl":
                    Inventory.Add("Girl");
                    CollectedItems.text += "Girl, ";
                    Destroy(collision.gameObject);
                    Girl.GetComponent<Image>().color = startingColor;
                    break;
                case "Phone":
                    Inventory.Add("Phone");
                    CollectedItems.text += "Phone, ";
                    Destroy(collision.gameObject);
                    Phone.GetComponent<Image>().color = startingColor;
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

        if (collision.gameObject.tag == "GreenKey")
        {
            GreenKey.GetComponent<Image>().color = startingColor;
            Inventory.Add(collision.gameObject.name);
            foreach (var item in Inventory)
            {
                Uitext += item + ", ";
            }
            CollectedItems.text = Uitext;
            Destroy(collision.gameObject);
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
