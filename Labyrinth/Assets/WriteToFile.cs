using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class WriteToFile : MonoBehaviour
{
    public InputField Nickname;
    // Start is called before the first frame update
   public void Write()
    {
        File.AppendAllText(@"../scores.txt", Nickname + Environment.NewLine);
    }
}
