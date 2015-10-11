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
    private Selectable[] menuControls;
    private int menuControlsIndex = 0;

    void FixedUpdate()
    {
        //collectGamepadInput();
    }

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

        menuControls = new Selectable[] { playButton, difficultySlider, darkToggle, lightToggle, introButton, quitButton };
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void AdjustDifficulty()
    {
        difficultyOutput.text = difficultyLevels[(int)difficultySlider.value];
    }

    private void collectGamepadInput()
    {
        if (Input.GetAxis("Vertical") < -0.5f)
        {
            if (menuControlsIndex == 0)
            {
                menuControlsIndex = menuControls.Length;print("asd");
            }
            menuControls[--menuControlsIndex].Select();
        }
    }
}