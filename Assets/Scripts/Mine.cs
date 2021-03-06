﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {
    public GameObject MineStone;
    //public GameObject Camera;
    MineStone mineScript;
    CameraShake cameraShake;
    public GameObject PS_Sparks;
    public GameObject PS_Impact;
    Animator animator;
    public AudioClip[] hitSound;
    AudioSource audio;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        mineScript = MineStone.GetComponent<MineStone>();
        cameraShake = MineStone.GetComponent<CameraShake>();
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("Mining", true);
        }
        else
        {
            animator.SetBool("Mining", false);
        }
	}
    void Spark()
    {
        if (mineScript.rayHit != null && mineScript.stones < mineScript.inventorySize)
        {
            audio.clip = hitSound[Random.Range(0, hitSound.Length)];
            audio.Play();
            mineScript.addStones = true;

            mineScript.stones += (int)mineScript.rayHit.stonesPerHit;

            Instantiate(PS_Impact, mineScript.hit.point, Quaternion.LookRotation(mineScript.hit.normal));
            Instantiate(PS_Sparks, mineScript.hit.point, Quaternion.LookRotation(mineScript.hit.normal));
            cameraShake.shakeDuration += 0.2f;
        }
        else
        {
            mineScript.addStones = false;
        }
    }
}
