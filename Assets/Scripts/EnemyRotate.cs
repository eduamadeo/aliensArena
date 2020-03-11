using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotate : MonoBehaviour
{
    public float rotationSpeed = 80.0f;
    private Rigidbody enemyRigidbody;
    // Start is called before the first frame update
    private void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Mathf.Abs(enemyRigidbody.velocity.x) > 0)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        }

    }
}
