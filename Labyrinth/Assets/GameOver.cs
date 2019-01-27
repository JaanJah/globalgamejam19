using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Stopwatch stopwatch;
    public Text TimeElapsed;
    private static string elapsedTime;
    private bool GameOverBool;
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        stopwatch = new Stopwatch();
        stopwatch.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (stopwatch.IsRunning == true)
        {
            var ts = stopwatch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            HoldValue.ElapsedTime = elapsedTime;
            TimeElapsed.text = elapsedTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && !GameOverBool)
        {
            GameOverBool = true;
            stopwatch.Stop();
            //File.AppendAllText(@"../scores.txt", elapsedTime + " ");
            anim.SetTrigger("fadeout");
        }
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene("ShareNickname");
    }
}
