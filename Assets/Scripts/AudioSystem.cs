using UnityEngine;
using System.Collections;
using System;

public class AudioSystem : MonoBehaviour {


    public GameObject[] spawnList; //spawn list
    public GameObject Enemy; //Enemy prefab

    private DamierLoader damLoad;
    private FloorRythm floorRythm;

    public float cooldown = 0.0f;//cooldown in between enemy spawn


    public float spawnThreshold = 0.5f;
    public int frequency=0;


    private float[] samples = new float[1024];
    public FFTWindow fftWindow;

    public int BPM=130;
    public float debugvalue;

    public float timerBPM=130;

    private System.Random random;

	// Use this for initialization
	void Start () {

   


    damLoad = GameObject.Find("FullDamier").GetComponent<DamierLoader>();
        floorRythm = GameObject.Find("RythmBoxes").GetComponent<FloorRythm>();
        random = new System.Random();
        //BPM = GameObject.Find("Main Camera").GetComponent<SceneSetup>().BPM;
        timerBPM = 1.0f / (BPM / 60.0f);

        Debug.Log(MenuCtrl.FinalDifficulty);

    }
	
	// Update is called once per frame
	void Update() {

        if (timerBPM > 0.0f)
            timerBPM -= Time.deltaTime;
       if (timerBPM <= 0.0f)
       {
            damLoad.switchDamier();
            floorRythm.switchLane();
            timerBPM = 1.0f / (BPM / 60.0f);
       }

        if (cooldown > 0.0f)
            cooldown -= Time.deltaTime;

        debugvalue = samples[frequency];
        AudioListener.GetSpectrumData(samples, 0, fftWindow);


            

        if (samples[frequency] > spawnThreshold && cooldown<=0.0f)
        {
            GameObject ChosenspawnLocation = spawnList[random.Next(0, spawnList.Length)];
            Instantiate(Enemy, ChosenspawnLocation.transform.position, ChosenspawnLocation.transform.rotation);
            cooldown =  1.0f / (BPM / 60.0f);
            cooldown = cooldown * 1.0f;
        }
    }
}
