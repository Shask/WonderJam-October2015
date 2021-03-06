﻿using UnityEngine;
using System.Collections;

public class SimpleMoveEnemy : MonoBehaviour {

    public float speed = 3.0f;
    public bool seen = false;

    public float scaleSpeed = 3.0f;

    public float timerdestroy = -1.0f;

    public AudioSystem audioSys;
    private ScoreManager scoreManager;

    public GameObject[] KillOk;


    // Use this for initialization
    void Start()
    {
       // gameObject.renderer.sortingLayerName = "";
        audioSys = GameObject.Find("Audio System").GetComponent<AudioSystem>();
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerdestroy > 0.0f)
            timerdestroy -= Time.deltaTime;

        Vector3 scale = transform.localScale;
        scale = new Vector3(1,1,1) * ( 1.8f + audioSys.debugvalue);

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
            DestroyByOutofSight();

        //timer is finished -> destroy the object
        if (timerdestroy < 0.0f && timerdestroy!= -1.0f)
            Destroy(gameObject);
    }

    public void  DestroyedByPlayer()
    {
        scoreManager.Hit();
        Vector3 posParti = transform.position;
        posParti.z -= 2;
        int i = GetComponent<EnemyID>().EnemyType;
        GameObject go = (GameObject) Instantiate(KillOk[i-1], posParti, transform.rotation);
        go.GetComponent<ParticleSystem>().Play();
        //TODO Feed back succes
        Destroy(gameObject);
    }
    void DestroyByOutofSight()
    {
        timerdestroy = 2.0f;
        scoreManager.MissEnemy();
    }

    public void DestroyByBadinput()
    {
        //Change color + play a sound TODO
        Destroy(gameObject);
        scoreManager.WrongInput();
    }
}
