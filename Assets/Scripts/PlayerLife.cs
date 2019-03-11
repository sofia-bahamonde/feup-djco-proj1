using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    private Animator anim;
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
        GameManager.gm.SetLifes(-1);
        //audioScr.clip = dieSound;
        //audioScr.Play();

        if (GameManager.gm.GetLifes() > 0)
        {
            anim.SetTrigger("Hit");

        }else {
            anim.SetTrigger("Died");
            //gameObject.GetComponent<PlayerAttack>().enabled = false;
            gameObject.GetComponent<PlayerController>().enabled = false;

        }

    }

    public void Reset()
    {
        GameManager.gm.RestoreHud();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
