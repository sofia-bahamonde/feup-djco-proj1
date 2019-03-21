using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer mp;

    // Start is called before the first frame update
    void Awake()
    {
        if (mp == null)
        {
            mp = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StopMusic()
    {
        gameObject.GetComponent<AudioSource>().Stop();

    }
}
