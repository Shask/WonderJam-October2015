﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {


    public int score = 0;
    public int combo = 1;

    public int succesStrike = 0;


    private Text ScoreObj;
    private Text ComboObj;
    
	// Use this for initialization
	void Start () {
        ScoreObj = GameObject.Find("Score").GetComponent<Text>();
        ComboObj = GameObject.Find("Combo").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}


    public void Hit()
    {
        score += 100 * combo;
        succesStrike++;
        ComboManager();
        UpdateUI();
    }
  public void MissEnemy()
    {
        combo = 1;
        succesStrike = 0;
        UpdateUI();
    }

    public void MissPlacement()
    {
        combo = 1;
        UpdateUI();
    }
    public void WrongInput()
    {
        combo = 1;
        succesStrike = 0;
        UpdateUI();
    }

   private void ComboManager()
    {
        //increase the combo score every time the player do a succes strike of 5
        if (succesStrike % 5 == 1 && combo<=5)
            combo++;
       
    }

    private void UpdateUI()
    {
        ScoreObj.text = "Score : " + score;
        ComboObj.text = "Combo : " + combo;
    }
}