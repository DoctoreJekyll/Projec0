using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    private float length;
    private float startPos;
    public GameObject cam;
    public float parrallaxEffect;

    private void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;//Esto me devuelve el valor de los bordes del sprite en x
        cam = Camera.main.gameObject;
    }

    private void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parrallaxEffect));
        float dist = (cam.transform.position.x * parrallaxEffect);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
        if (temp > startPos + length)
        {
            startPos += length;
        }
        else if (temp < startPos - length)
        {
            startPos -= length;
        }
    }



}
