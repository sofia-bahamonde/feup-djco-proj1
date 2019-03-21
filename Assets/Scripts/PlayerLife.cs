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
    private bool check = true;
    private bool effectFadeOut = false;
    private bool effectFadeIn = false;
    public float fadeOutTime = 5.0f;
    private Color originalColor;

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
            if (GameManager.gm.IsPowerUp())
            {
                gameObject.GetComponent<CircleCollider2D>().radius = 0.08876744f;
                transform.Find("GroundCheck").position = new Vector3(transform.Find("GroundCheck").position.x + 0.017f, transform.Find("GroundCheck").position.y + 0.021f, 0);
                GameManager.gm.ChangePowerUp();
            }
            System.Threading.Thread.Sleep(500);

           
          GameOver();

        }

        if(effectFadeOut) {
            Color c = this.GetComponent<Renderer>().material.color;
            c.a -= Time.deltaTime * fadeOutTime;
            this.GetComponent<Renderer>().material.color = c;
            if(c.a < 0) {
                effectFadeOut = false;
                effectFadeIn = true;
            }
        }

        if(effectFadeIn){
            Color c = this.GetComponent<Renderer>().material.color;
            c.a += Time.deltaTime * fadeOutTime;
            if(c.a > 1){
                c.a = 1;
                effectFadeIn = false;
            }
            this.GetComponent<Renderer>().material.color = c;    
        }
    }

    public void LoseLife()
    {
        if (check)
        {
            check = false;
            Debug.Log(GameManager.gm.IsPowerUp());
            if (!GameManager.gm.IsPowerUp())
            {
                GameManager.gm.SetLifes(-1);
            }


            if (GameManager.gm.GetLifes() > 0)
            {

               

                audioScr.clip = hitSound;
                audioScr.Play();
                anim.SetTrigger("Hit");

                //gameObject.GetComponent<PlayerController>().enabled = false;

                if (GameManager.gm.IsPowerUp())
                {
                    gameObject.GetComponent<CircleCollider2D>().radius = 0.08876744f;
                    transform.Find("GroundCheck").position = new Vector3(transform.Find("GroundCheck").position.x + 0.017f, transform.Find("GroundCheck").position.y + 0.021f, 0);
                    GameManager.gm.ChangePowerUp();
                }


            }
            else
            {
                audioScr.clip = dieSound;
                audioScr.Play();
                anim.SetTrigger("Died");
                gameObject.GetComponent<PlayerController>().enabled = false;
                
                


            }

        }
    }

    public void Reset()
    {

        /* if(GameManager.gm.GetLifes() >= 0){
             SceneManager.LoadScene(SceneManager.GetActiveScene().name);
         }*/
        check = true;

    }

    public void GameOver(){
        GameManager.gm.RestoreHud();
          SceneManager.LoadScene("GameOver");
    }

    public void PowerUp()
    {
        effectFadeOut = true;
        originalColor = this.GetComponent<Renderer>().material.color;
        GameManager.gm.ChangePowerUp();
        gameObject.GetComponent<CircleCollider2D>().radius = 0.1927377f;
        transform.Find("GroundCheck").position = new Vector3(transform.Find("GroundCheck").position.x - 0.017f, transform.Find("GroundCheck").position.y - 0.021f,0);
        anim.SetTrigger("PowerUp");

    }

}
