using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {


    public static int score = 0;
    public int combo = 1;

    public int succesStrike = 0;

    public static int NumberDestroyedPixel = 0;
    public static int NumberunDestroyedPixel = 0;
    public static int NumberMissedButton = 0;
    public static float TimeOnbadTempo = 0.0f;
    public static float LongestTimeOnBadTempo = 0.0f;
    public static int MaxComboReached = 0;
   // public int LongestStreak = 0;


    private float timerResetScoreCol;
    private float timerResetComboCol;

    public float CDResetCol;

    private Text ScoreObj;
    private Text ComboObj;


    private Color InitialScoreObjColor;
    private Color InitialComboObjColor;
    private int InitialScoreObjfont;
    private int InitialComboObjfont;


    private int SpeedFontSize = 30;


    // Use this for initialization
    void Start () {
        ScoreObj = GameObject.Find("Score").GetComponent<Text>();
        ComboObj = GameObject.Find("Combo").GetComponent<Text>();
        InitialComboObjColor = ComboObj.color;
        InitialScoreObjColor=  ScoreObj.color;

        InitialComboObjfont = ComboObj.fontSize;
        InitialScoreObjfont = ScoreObj.fontSize;
        CDResetCol = 2 / (130 / 60);

        if (false) //new game
        {
            NumberDestroyedPixel = 0;
            NumberunDestroyedPixel = 0;
            NumberMissedButton = 0;
            TimeOnbadTempo = 0.0f;
            LongestTimeOnBadTempo = 0.0f;
            MaxComboReached = 0;
        }
}
	
	// Update is called once per frame
	void Update () {

        if (timerResetScoreCol > 0.0f)
            timerResetScoreCol -= Time.deltaTime;

        if (timerResetComboCol > 0.0f)
            timerResetComboCol -= Time.deltaTime;

        if (ComboObj.fontSize != InitialComboObjfont)
            ComboObj.fontSize = (int) (ComboObj.fontSize - (SpeedFontSize * Time.deltaTime));

        
        if (ScoreObj.fontSize != InitialScoreObjfont)
            ScoreObj.fontSize = (int)(ScoreObj.fontSize -SpeedFontSize * Time.deltaTime);

        if (timerResetScoreCol <= 0.0f && ScoreObj.color != InitialScoreObjColor)
            ScoreObj.color = InitialScoreObjColor;


        if (timerResetComboCol <= 0.0f && ComboObj.color != InitialComboObjColor)
            ComboObj.color = InitialComboObjColor;


    }


    public void Hit()
    {
        Debug.Log("hit");
        score +=( 100 * combo);
        succesStrike++;
        ComboManager();
        UpdateUI(1,0);
        NumberDestroyedPixel++;
    }
  public void MissEnemy()
    {
        combo = 1;
        succesStrike = 0;
        UpdateUI(0,-1);
        NumberMissedButton++;
    }

    public void MissPlacement()
    {
        Debug.Log("Desyncro");
        if(combo>1)
        {
            combo -= 1;
            UpdateUI(0, -1);
        }
        
        succesStrike = 0;
        
    }
    public void WrongInput()
    {
        combo = 1;
        succesStrike = 0;
        UpdateUI(0,-1);
        NumberMissedButton++;
    }

    private void ComboManager()
    {
        //increase the combo score every time the player do a succes strike of 3
        if (succesStrike/3 > 0.9f && combo < 5)
        { 
          combo++;
          succesStrike = 0;
          UpdateUI(0, 1);
        }

    }

    private void UpdateUI(int Score,int Combo)
    {
        ScoreObj.text = "Score : " + score;
        ComboObj.text = "x" + combo;

        if(Score == 1) {
            ScoreObj.fontSize = InitialScoreObjfont + 20;
        }
        
        if (Score == -1) {
            ScoreObj.fontSize = InitialScoreObjfont + 20;
            ScoreObj.color = Color.red;
            timerResetScoreCol = CDResetCol;
        }
        //Turn Red
        if (Combo == 1) {
            ComboObj.fontSize = InitialComboObjfont + 20;
            ComboObj.color = Color.green;
            timerResetComboCol = CDResetCol;
        }
        if (Combo == -1) {
            ComboObj.fontSize = InitialComboObjfont + 20;
            ComboObj.color = Color.red;
            timerResetComboCol = CDResetCol;
        }

        if (combo > MaxComboReached)
            MaxComboReached = combo;

    }
}
