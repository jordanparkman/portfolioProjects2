using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitZone : MonoBehaviour {

    SpriteRenderer sr;
    public KeyCode key; //Gets the key that the HitZone is linked to.
    bool active = false; //False when there is no note in the hit zone.
    GameObject note, mg;
    Color old;
    public bool createMode;
    public GameObject noteCreateMode;

    void Awake ()
    {
        sr = GetComponent<SpriteRenderer>();
    }

	// Use this for initialization
	void Start () {
        old = sr.color;
        mg = GameObject.Find("ManageGame");
	}
	
	// Update is called once per frame
	void Update () {

        if (createMode && Input.GetKeyDown(key))
        {
            if (Input.GetKeyDown(key))
            {
                Instantiate(noteCreateMode, transform.position, Quaternion.identity);
            }
        }
        else
        {
            if (Input.GetKeyDown(key))
            {
                StartCoroutine(Pressed());
            }

            if (Input.GetKeyDown(key) && active)
            {
                Destroy(note);
                mg.GetComponent<ManageGame>().AddStreak();
                AddScore();
                active = false;
            } else if (Input.GetKeyDown(key) && !active)
            {
                mg.GetComponent<ManageGame>().ResetStreak();              
            }
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {

        if(col.gameObject.tag == "WinTag")
        {
            mg.GetComponent<ManageGame>().Win();
        }

        if (col.gameObject.tag == "Note")
        {
            note = col.gameObject;
            active = true; //True, because there is a note in the hit zone.
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        active = false; //When the note leaves the hit zone, return active status to false
        //mg.GetComponent<ManageGame>().ResetStreak();
    }

    IEnumerator Pressed()
    {
        sr.color = new Color(1, 1, 1);
        yield return new WaitForSeconds(0.1f);
        sr.color = old;
    }

    void AddScore()
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + mg.GetComponent<ManageGame>().GetScore());
    }
}
