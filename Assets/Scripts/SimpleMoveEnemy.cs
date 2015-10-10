using UnityEngine;
using System.Collections;

public class SimpleMoveEnemy : MonoBehaviour {

    public float speed = 3.0f;
    public bool seen = false;

    public float scaleSpeed = 3.0f;

    public float timerdestroy = -1.0f;

    private AudioSystem audioSys;
    private ScoreManager scoreManager;


    // Use this for initialization
    void Start()
    {
        audioSys = GameObject.Find("Audio System").GetComponent<AudioSystem>();
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerdestroy > 0.0f)
            timerdestroy -= Time.deltaTime;

        Vector3 scale = transform.localScale;
        scale = new Vector3(1,1,1) * ( 1.5f + audioSys.debugvalue);

        // Condition that provide enemy to flicker (when the change of scale is rly low)
        if (scale.x - transform.localScale.x <= 0.05f && scale.x - transform.localScale.x >= -0.05f) { }
        else
            transform.localScale = scale;

        float t = Time.deltaTime;
        Vector3 pos = transform.position;
        pos.y += t * speed;
        transform.position = pos;

        if (GetComponent<Renderer>().isVisible)
            seen = true;

        if (seen && !GetComponent<Renderer>().isVisible && timerdestroy == -1.0f)
            timerdestroy = 2.0f;

        //timer is finished -> destroy the object
        if (timerdestroy < 0.0f && timerdestroy!= -1.0f)
            Destroy(gameObject);
    }

    void DestroyedByPlayer()
    {
        timerdestroy = 2.0f;
        scoreManager.Hit();
    }
    void DestroyByOutofSight()
    {
        timerdestroy = 2.0f;
        scoreManager.MissEnemy();
    }
}
