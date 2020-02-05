﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{

    public Text winText;
    public Text livesText;

    private int lives;

    // Start is called before the first frame update
    void Start()
    {
        lives = 5;
        winText.text = "";
        SetLivesText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            lives = lives - 1;
            livesText.text = lives.ToString();
            //Destroy(collision.collider.gameObject);
            //collision.gameObject.SetActive(false);
            SetLivesText();
        }
    }

    private void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
        if (lives == 0)
        {
            Object.Destroy(gameObject);
            winText.text = "You Lose!";
            
        }
    }
}
