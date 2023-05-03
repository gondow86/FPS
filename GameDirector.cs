using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    GameObject scoreText;
    GameObject comboText;
    public float time;
    public static int score = 0;
    string t = "Time: ";
    string s = "Score: ";
    string co = "Combo";
    RaycastHit hit;
    public AudioSource a;
    public AudioSource b;
    public AudioSource c;
    public AudioClip CountDown;
    public AudioClip GameOver;
    public AudioClip ShootHit;
    bool GameOverTrigger = false;
    int comboCount = 0;

    //private void OnGUI()
    //{
        //Debug.Log(comboCount);
       // string s = comboCount.ToString() + " Combo!";
        //GUI.Label(new Rect(200, 200, 300, 300), s);
    //}
    public void ShootTarget1()
    {
        score += 100;
        c.PlayOneShot(ShootHit);
        comboCount = 1;
    }
    public void ShootTarget2()
    {
        score += 200;
        c.PlayOneShot(ShootHit);
        comboCount = 2;
    }
    public void ShootTarget3()
    {
        score += 300;
        c.PlayOneShot(ShootHit);
        comboCount = 3;
    }
    public void ShootTarget4()
    {
        score += 500;
        c.PlayOneShot(ShootHit);
        comboCount = 4;
    }
    public void ShootTarget5()
    {
        score += 1000;
        c.PlayOneShot(ShootHit);
        this.comboCount++;
    }

    public static int getscore()
    {
        return score;
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        this.timerText = GameObject.Find("Time");
        this.scoreText = GameObject.Find("Score");
        this.comboText = GameObject.Find("Combo");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("TitleScene");
        }
        this.time -= Time.deltaTime;
        if (this.time > 0f)
        {
            this.timerText.GetComponent<Text>().text = t + this.time.ToString("F1");
            this.scoreText.GetComponent<Text>().text = s + score.ToString();
            this.comboText.GetComponent<Text>().text = comboCount.ToString() + co;
            if (this.time < 1.0f && !GameOverTrigger)
            {
                GameOverTrigger = true;
                b.PlayOneShot(GameOver);
                Debug.Log("gameover");
            }
        } else
        {
            SceneManager.LoadScene("GameOverScene");    
        }

    }

}
