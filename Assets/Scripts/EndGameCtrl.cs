using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class EndGameCtrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("Score").GetComponent<Text>().text = ScoreManager.score + "";
        GameObject.Find("Landed Hit").GetComponent<Text>().text = ScoreManager.landedHit + "";
        GameObject.Find("Rythm").GetComponent<Text>().text = (int)(ScoreManager.TimeOnbadTempo) + "";
        GameObject.Find("Wrong Attack").GetComponent<Text>().text = ScoreManager.NumberMissedButton + "";
        GameObject.Find("Pixel Destroyed").GetComponent<Text>().text = ScoreManager.NumberDestroyedPixel + "";
        GameObject.Find("Pixel Escape").GetComponent<Text>().text = ScoreManager.NumberunDestroyedPixel + "";
        GameObject.Find("Combo Sucess").GetComponent<Text>().text = ScoreManager.MaxComboReached + "";
    }
	
	// Update is called once per frame
	void Update () {
    }
}
