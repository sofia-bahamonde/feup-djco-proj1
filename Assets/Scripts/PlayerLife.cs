using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    private Animator anim;
    private bool alive = true;
    public AudioClip dieSound;
    private AudioSource audioScr;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        //audioScr = gameObject.GetComponent<AudioSource>();
        GameManager.gm.Refresh();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoseLife()
    {
        if (alive)
        {
            //audioScr.clip = dieSound;
            //audioScr.Play();
            alive = false;
            anim.SetTrigger("Hit");
            GameManager.gm.SetLifes(-1);
            // gameObject.GetComponent<PlayerAttack>().enabled = false;
            //gameObject.GetComponent<PlayerController>().enabled = false;
        }

    }

    public void Reset()
    {
        if (GameManager.gm.GetLifes() > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
