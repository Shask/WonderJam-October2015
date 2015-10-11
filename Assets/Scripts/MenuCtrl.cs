﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MenuCtrl : MonoBehaviour
{
    private Text difficultyOutput;
    private String[] difficultyLevels = { "Tutoriel", "Facile", "Moyen", "Difficile" };
    private Slider difficultySlider;
    private Button playButton;

    void FixedUpdate()
    {
    }

    void Start()
    {
        Cursor.visible = false;

        difficultyOutput = GameObject.Find("Difficulty Output").GetComponent<Text>();
        difficultySlider = GameObject.Find("Difficulty").GetComponent<Slider>();
        playButton = GameObject.Find("Play").GetComponent<Button>();

        playButton.Select();
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void AdjustDifficulty()
    {
        difficultyOutput.text = difficultyLevels[(int)difficultySlider.value];
    }
}