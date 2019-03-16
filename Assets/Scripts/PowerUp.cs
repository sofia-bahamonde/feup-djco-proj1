using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    Animator anim;
    BoxCollider2D col;
    private AudioSource audioScr;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        col = gameObject.GetComponent<BoxCollider2D>();
        //audioScr = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           // audioScr.Play();
            col.enabled = false;
            anim.SetTrigger("Collect");
            if (GameManager.gm.IsPowerUp())
            {
                GameManager.gm.SetLifes(1);
            }
            else
            {
                other.gameObject.GetComponent<PlayerLife>().PowerUp();
            }
            Destroy(gameObject, 1);
        }

    }
}
