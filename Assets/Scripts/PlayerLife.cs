using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    private Animator anim;
    public AudioClip dieSound;
    public AudioClip hitSound;
    public int playerFall;
    private AudioSource audioScr;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        audioScr = gameObject.GetComponent<AudioSource>();
        GameManager.gm.Refresh();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(gameObject.transform.position.y < playerFall)
        {
            audioScr.clip = dieSound;
            audioScr.Play();
            gameObject.GetComponent<PlayerController>().enabled = false;
            System.Threading.Thread.Sleep(500);
            GameManager.gm.RestoreHud();
            Reset();
        }
    }

    public void LoseLife()
    {
        GameManager.gm.SetLifes(-1);

        if (GameManager.gm.GetLifes() > 0)
        {
            audioScr.clip = hitSound;
            audioScr.Play();
            anim.SetTrigger("Hit");

        }else {
            audioScr.clip = dieSound;
            audioScr.Play();
            anim.SetTrigger("Died");
            //gameObject.GetComponent<PlayerAttack>().enabled = false;
            gameObject.GetComponent<PlayerController>().enabled = false;
            GameManager.gm.RestoreHud();

        }

    }

    public void Reset()
    {
    
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
