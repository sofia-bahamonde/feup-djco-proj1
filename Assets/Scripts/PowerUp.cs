using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PowerUp : MonoBehaviour
{
    Animator anim;
    BoxCollider2D col;
    private AudioSource audioScr;
    public float fadeOutTime = 2.0f;
    bool hasCollision = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        col = gameObject.GetComponent<BoxCollider2D>();
        audioScr = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hasCollision) {
            Color c = this.GetComponent<Renderer>().material.color;
            c.a -= Time.deltaTime * fadeOutTime;
            this.GetComponent<Renderer>().material.color = c;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioScr.Play();
            col.enabled = false;
            anim.SetTrigger("Collect");
            if (GameManager.gm.IsPowerUp())
            {
                GameManager.gm.SetLifes(1);
            }
            else
            {
                other.gameObject.GetComponent<PlayerLife>().PowerUp();
                hasCollision = true;
            }
           Destroy(gameObject, 1);
        }

    }
}
