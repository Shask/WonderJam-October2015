using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MenuCtrl : MonoBehaviour
{
    private Text difficultyOutput;
    public static string FinalDifficulty = "Tutoriel";
    public static String[] difficultyLevels = { "Tutoriel", "Moyen", "Difficile", "HardCore" };
    public static bool isPale;
    private Slider difficultySlider;
    private Button playButton;

    void FixedUpdate()
    {
    }

    void Start()
    {
        //DontDestroyOnLoad(this);
        Cursor.visible = false;

        difficultyOutput = GameObject.Find("Difficulty Output").GetComponent<Text>();
        difficultySlider = GameObject.Find("Difficulty").GetComponent<Slider>();
        playButton = GameObject.Find("Play").GetComponent<Button>();
        isPale = GameObject.Find("Pale").GetComponent<Toggle>().isOn;
        playButton.Select();
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void AdjustDifficulty()
    {
        difficultyOutput.text = difficultyLevels[(int)difficultySlider.value];
        FinalDifficulty = difficultyLevels[(int)difficultySlider.value];
    }
}