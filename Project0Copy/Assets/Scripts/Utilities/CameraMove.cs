using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1f, 0f, 0f) * Time.deltaTime);
    }
}
