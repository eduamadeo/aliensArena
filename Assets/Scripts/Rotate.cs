using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 80.0f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        if(Input.acceleration.x > .2f)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        } else if(Input.acceleration.x < -.2f)
        {
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        } else
        {
            transform.Rotate(new Vector3(0, 0, 0));
        }
       
    }
}
