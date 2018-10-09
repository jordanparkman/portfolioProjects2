using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageGame : MonoBehaviour {

    int multiplier = 1;
    int streak = 0;
    float health = 100f;

    public Image healthbar;

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("Score", 0);
        //PlayerPrefs.SetInt("Meter", 50);
        PlayerPrefs.SetInt("Streak", 0);
        PlayerPrefs.SetInt("HighStreak", 0);
        PlayerPrefs.SetInt("Mult", 1);
        PlayerPrefs.SetInt("Start", 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
        health -= 5;
        healthbar.fillAmount = health / 100f; 
        ResetStreak();
        if (healthbar.fillAmount <= 0)
        {
            Lose();
        }
    }

    public void AddStreak()
    {
        streak++;
        //multiplier = (int+1)streak / 10;
        if (streak >= 50)
            multiplier = 5;
        else if (streak >= 40)
            multiplier = 4;
        else if (streak >= 30)
            multiplier = 3;
        else if (streak >= 20)
            multiplier = 2;
        else 
            multiplier = 1;

        if (streak > PlayerPrefs.GetInt("HighStreak"))
            PlayerPrefs.SetInt("HighStreak", streak);

        UpdateGUI();
    }

    public void ResetStreak()
    {
        streak = 0;
        multiplier = 1;
        UpdateGUI();
    }

    void Lose()
    {
        PlayerPrefs.SetInt("Start", 0);
        SceneManager.LoadScene(2);
    }

    public void Win()
    {
        PlayerPrefs.SetInt("Start", 0);
        if (PlayerPrefs.GetInt("HighScore")<PlayerPrefs.GetInt("Score"))
        PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
        SceneManager.LoadScene(2);
    }

    void UpdateGUI()
    {
        PlayerPrefs.SetInt("Streak", streak);
        PlayerPrefs.SetInt("Mult", multiplier);
    }

    public int GetScore()
    {
        return 50 * multiplier;
    }
}
