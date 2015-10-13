using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MenuCtrl : MonoBehaviour
{
    private Text difficultyOutput;
    public static string FinalDifficulty = "Tutoriel";
    public static String[] difficultyLevels = { "Tutoriel", "Moyen", "Difficile", "HardCore" };
    public static bool FirstChar;
    private Slider difficultySlider;
    private Button playButton;

    private bool LastplayerPick;

    void FixedUpdate()
    {
        if (GameObject.Find("Pale").GetComponent<Toggle>().isOn != LastplayerPick)
        {
            LastplayerPick = !LastplayerPick;
            FirstChar = !FirstChar;
         }
    }

    void Start()
    {
        //DontDestroyOnLoad(this);
        Cursor.visible = false;

        difficultyOutput = GameObject.Find("Difficulty Output").GetComponent<Text>();
        difficultySlider = GameObject.Find("Difficulty").GetComponent<Slider>();
        playButton = GameObject.Find("Play").GetComponent<Button>();
        LastplayerPick = GameObject.Find("Pale").GetComponent<Toggle>().isOn;
        FirstChar = LastplayerPick;
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