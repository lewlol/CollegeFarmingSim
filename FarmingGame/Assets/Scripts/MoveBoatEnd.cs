using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoatEnd : MonoBehaviour
{
    float speed = 15f;

    private void Update()
    {
        Move();
    }
    void Move()
    {
        transform.position = transform.position += new Vector3(0, 0, speed * Time.deltaTime);
    }
}
