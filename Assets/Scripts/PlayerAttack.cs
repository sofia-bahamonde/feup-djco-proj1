using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackInterval;
    private float nextAttack;
    private Animator anim;
    public AudioClip attackSound;
    private AudioSource audioScr;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        //audioScr = gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextAttack && GameManager.gm.IsPowerUp())
        {
            Attack();
        }
    }


    void Attack()
    {
        //audioScr.clip = attackSound;
        //audioScr.Play();
        anim.SetTrigger("Attack");
        nextAttack = Time.time + attackInterval;
    }
}
