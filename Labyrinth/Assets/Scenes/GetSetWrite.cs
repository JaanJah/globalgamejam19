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
    public Text HiScores;
    public GameObject HiScores2;
    public GameObject Input2;
    public GameObject Button2;
    public InputField Input;
    public Button Button;
    // Start is called before the first frame update

    private void Start()
    {
        HiScores2.SetActive(false);
    }
    public void GetSet()
    {
        if (Nickname.text != "")
        {
            File.AppendAllText(@"../scores.txt", HoldValue.ElapsedTime + " " + Nickname.text + Environment.NewLine);
            Input2.SetActive(false);
            Button2.SetActive(false);
            HiScores2.SetActive(true);
            GetScores();
        }
        else
        {
            Warning.text = "Please enter something different";
        }
        
    }

    public void GetScores()
    {
        var Laps = 1;
        HiScores.text = "Hiscores:\n";
        var lines = File.ReadAllLines(@"../scores.txt");
        bool moreThanFiveScores = false;
        int skipLines = 0;
        if (lines.Length > 4)
        {
            skipLines = lines.Length - 4;
            moreThanFiveScores = true;
        }
        foreach (var line in lines)
        {
            if (moreThanFiveScores == true && skipLines != 0)
            {
                skipLines -= 1;
            }
            else
            {
                if (Laps == lines.Length)
                {
                    HiScores.text += "\nYour Score:\n" + line.ToString(); 
                }
                else
                {
                    HiScores.text += line.ToString() + "\n";
                    Laps++;
                }            
            }
        }
    }

}
