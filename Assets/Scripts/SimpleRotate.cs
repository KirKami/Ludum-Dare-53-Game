using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotate : MonoBehaviour
{
    public Vector3 rotate;
    public Space relative;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotate * Time.deltaTime, relative);
    }
}
