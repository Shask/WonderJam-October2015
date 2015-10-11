using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class EndGameCtrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("Score").GetComponent<Text>().text = ScoreManager.score + "";
        GameObject.Find("Combo Fail").GetComponent<Text>().text = Math.Round(ScoreManager.LongestTimeOnBadTempo, 2) + "  sec";
        GameObject.Find("Rythm").GetComponent<Text>().text = (int)(ScoreManager.TimeOnbadTempo) + "  sec";
        GameObject.Find("Wrong Attack").GetComponent<Text>().text = ScoreManager.NumberMissedButton + "";
        GameObject.Find("Pixel Destroyed").GetComponent<Text>().text = ScoreManager.NumberDestroyedPixel + "";
        GameObject.Find("Pixel Escape").GetComponent<Text>().text = ScoreManager.NumberunDestroyedPixel + "";
        GameObject.Find("Combo Sucess").GetComponent<Text>().text = ScoreManager.MaxComboReached + "";
    }
	
	// Update is called once per frame
	void Update () {
    }
}
