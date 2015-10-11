using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MenuCtrl : MonoBehaviour
{
    private Text difficultyOutput;
    private String[] difficultyLevels = { "Tutoriel", "Facile", "Moyen", "Difficile" };
    private Slider difficultySlider;
    private Button playButton, introButton, quitButton;
    private Toggle darkToggle, lightToggle;

    void Start()
    {
        difficultyOutput = GameObject.Find("Difficulty Output").GetComponent<Text>();
        difficultySlider = GameObject.Find("Difficulty").GetComponent<Slider>();
        playButton = GameObject.Find("Play").GetComponent<Button>();
        introButton = GameObject.Find("Intro").GetComponent<Button>();
        quitButton = GameObject.Find("Quit").GetComponent<Button>();
        darkToggle = GameObject.Find("Color 0").GetComponent<Toggle>();
        lightToggle = GameObject.Find("Color 1").GetComponent<Toggle>();

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