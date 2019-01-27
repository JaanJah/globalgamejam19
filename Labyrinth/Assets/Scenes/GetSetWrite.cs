using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;

public class GetSetWrite : MonoBehaviour
{
    public Text Nickname;
    public Text Warning;

    public GameObject Input2;
    public InputField Input;
    public Button Button;
    // Start is called before the first frame update
    public void GetSet()
    {
        if (Nickname.text != "")
        {
            File.AppendAllText(@"../scores.txt", Nickname.text + Environment.NewLine);
            //Input2.SetActive(false);
        }
        else
        {
            Warning.text = "Please enter something different";
        }
        
    }
}
