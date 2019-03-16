using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    private int lifes = 2;
    private int beers = 0;

    // Start is called before the first frame update
    void Awake()
    {
        if (gm == null)
        {
            gm = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Refresh();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SetLifes(int lif)
    {
        lifes += lif;
        Refresh();
    }

    public int GetLifes()
    {
        return lifes;
    }


    public void Refresh()
    {
        GameObject.Find("LifeText").GetComponent<Text>().text = lifes.ToString();
        GameObject.Find("CollectableText").GetComponent<Text>().text = beers.ToString();
    }

    public int GetBeers()
    {
        return beers;
    }
    public void SetBeers(int br)
    {
        
        beers += br;
       
        if (beers >= 10)
        {
            beers = 0;
            lifes += 1;
        }
        Refresh();
    }

    public void RestoreHud()
    {
        beers = 0;
        lifes = 2;
    }


}
