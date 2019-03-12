using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    Animator anim;
    BoxCollider2D col;
    private AudioSource audioScr;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        col = gameObject.GetComponent<BoxCollider2D>();
       // audioScr = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //audioScr.Play();
            GameManager.gm.SetBeers(1);
            col.enabled = false;
            anim.SetTrigger("PickUp");
            Destroy(gameObject, 1);
        }

    }
}



