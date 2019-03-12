using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject platform;
    public float speed;
    Transform currentPoint;
    public Transform[] points;
    public int pointSelector;
    // Start is called before the first frame update
    void Start()
    {
        currentPoint = points[pointSelector];
    }

    // Update is called once per frame
    void Update()
    {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPoint.position, Time.deltaTime * speed);

        if(platform.transform.position== currentPoint.position){
            pointSelector++;

            if(pointSelector == points.Length){
                pointSelector =0;
            }

            currentPoint = points[pointSelector];
        }
    }
}
