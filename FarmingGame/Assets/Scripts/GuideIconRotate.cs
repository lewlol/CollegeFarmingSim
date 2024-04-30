using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideIconRotate : MonoBehaviour
{
    Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        transform.LookAt(cam.transform.position);
    }
}
