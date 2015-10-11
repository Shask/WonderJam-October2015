using UnityEngine;
using System.Collections;

public class SceneSetup : MonoBehaviour {

    //Rappel  public static String[] difficultyLevels = { "Tutoriel", "Facile", "Moyen", "Difficile" };
    public struct difficultySettup
    {
        public string songName;
        public int BPM;
        public float SpwnTh;
        public int Frequence;
    }
    private int difficulty;


    public int BPM;
    public static string songName;

    public AudioClip[] songs;
    private difficultySettup[] d;


    // Use this for initialization
    void Start()
    {
        d = new difficultySettup[4];
        d[0].songName = "Unwritten Return.mp3";
        d[0].BPM = 80;
        d[0].Frequence = 9;
        d[0].SpwnTh = 0.05f;

        d[1].songName = "Dirty_Ways.mp3";
        d[1].BPM = 130;
        d[1].Frequence = 9;
        d[1].SpwnTh = 0.05f;

        d[2].songName = "Sonic_RoyalFree.mp3";
        d[2].BPM = 140;
        d[2].Frequence = 9;
        d[2].SpwnTh = 0.12f;

        d[3].songName = "MegaMan_RoyalFree.mp3";
        d[3].BPM = 180;
        d[3].Frequence = 9;
        d[3].SpwnTh = 0.055f;

        for (int i = 0; i < MenuCtrl.difficultyLevels.Length; i++)
            if (MenuCtrl.difficultyLevels[i] == MenuCtrl.FinalDifficulty)
                difficulty = i;

        BPM = d[difficulty].BPM;
        songName = d[difficulty].songName;

        Debug.Log(BPM);



        GetComponent<AudioSource>().clip = songs[difficulty];

        GetComponent<AudioSource>().Play();
        SetAllBPM();
        GameObject.Find("Audio System").GetComponent<AudioSystem>().spawnThreshold = d[difficulty].SpwnTh;
        GameObject.Find("Audio System").GetComponent<AudioSystem>().frequency= d[difficulty].Frequence;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void SetAllBPM()
    {
        GameObject.Find("Audio System").GetComponent<AudioSystem>().BPM = BPM;
        GameObject.Find("FullDamier").GetComponent<DamierLoader>().BPM = BPM;
        GameObject.Find("Score Manager").GetComponent<ScoreManager>().BPM = BPM;

      
    }
}
