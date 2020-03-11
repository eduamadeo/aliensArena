using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 15f;
    private float health = 100f;
    private Renderer rend;
    private bool recovering = false;
    private Rigidbody enemyRigidBody;
    public Vector3 localVelocity;
    public float mVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        enemyRigidBody = GetComponent<Rigidbody>();
        int side = Random.Range(1, 2);
        if (Mathf.Abs(enemyRigidBody.position.x) > 34 && Mathf.Abs(enemyRigidBody.position.x) < 36)
        {
            if(side == 1)
            {
                enemyRigidBody.velocity = new Vector3(0, 0, speed);
            } else
            {
                enemyRigidBody.velocity = new Vector3(0, 0, -1*speed);
            }
        } else
        {
            if (side == 1)
            {
                enemyRigidBody.velocity = new Vector3(speed, 0, 0);
            }
            else
            {
                enemyRigidBody.velocity = new Vector3(-1 * speed, 0, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        localVelocity = enemyRigidBody.velocity;
        mVelocity = localVelocity.magnitude;
        int side = Random.Range(1, 5);
        int side2 = Random.Range(1, 4);
        if (isValueBetween(enemyRigidBody.position.x, 34.9f, 35.15f) && isValueBetween(enemyRigidBody.position.z, 34.9f, 35.15f))
        {
            if(side == 1 || side == 2)
            {
                enemyRigidBody.velocity = new Vector3(0, 0, -1 * speed);
            } else
            {
                enemyRigidBody.velocity = new Vector3(-1 * speed, 0, 0);
            }
        } else if (isValueBetween(enemyRigidBody.position.x, 34.9f, 35.15f) && isValueBetween(enemyRigidBody.position.z, -35.15f, -34.9f))
        { 
            if (side == 1 || side == 2)
            {
                enemyRigidBody.velocity = new Vector3(0, 0, speed);
            }
            else
            {
                enemyRigidBody.velocity = new Vector3(-1 * speed, 0, 0);
            }
        } else if (isValueBetween(enemyRigidBody.position.x, -35.15f, -34.9f) && isValueBetween(enemyRigidBody.position.z, -35.15f, -34.9f))
        {
            if (side == 1 || side == 2)
            {
                enemyRigidBody.velocity = new Vector3(0, 0, speed);
            }
            else
            {
                enemyRigidBody.velocity = new Vector3(speed, 0, 0);
            }
        } else if (isValueBetween(enemyRigidBody.position.x, -35.15f, -34.9f) && isValueBetween(enemyRigidBody.position.z, 34.9f, 35.15f))
        {
            if (side == 1 || side == 2)
            {
                enemyRigidBody.velocity = new Vector3(0, 0, -1*speed);
            }
            else
            {
                enemyRigidBody.velocity = new Vector3(speed, 0, 0);
            }
        } else if (isValueBetween(Mathf.Abs(enemyRigidBody.position.x), 14.9f, 15.15f) && isValueBetween(enemyRigidBody.position.z, 34.9f, 35.15f))
        {
            if(side2 == 1)
            {
                enemyRigidBody.velocity = new Vector3(speed, 0, 0);
            } else if(side2 == 2)
            {
                enemyRigidBody.velocity = new Vector3(-1*speed, 0, 0);
            } else
            {
                enemyRigidBody.velocity = new Vector3(0, 0, -1 * speed);
            }
        }
        else if (isValueBetween(Mathf.Abs(enemyRigidBody.position.x), 14.9f, 15.1f) && isValueBetween(enemyRigidBody.position.z, -35.1f, -34.9f))
        {
            if (side2 == 1)
            {
                enemyRigidBody.velocity = new Vector3(speed, 0, 0);
            }
            else if (side2 == 2)
            {
                enemyRigidBody.velocity = new Vector3(-1 * speed, 0, 0);
            }
            else
            {
                enemyRigidBody.velocity = new Vector3(0, 0, speed);
            }
        }
        else if (isValueBetween(Mathf.Abs(enemyRigidBody.position.z), 14.9f, 15.1f) && isValueBetween(enemyRigidBody.position.x, 34.9f, 35.1f))
        {
            if (side2 == 1)
            {
                enemyRigidBody.velocity = new Vector3(0, 0, speed);
            }
            else if (side2 == 2)
            {
                enemyRigidBody.velocity = new Vector3(0, 0, -1 * speed);
            }
            else
            {
                enemyRigidBody.velocity = new Vector3(-1 * speed, 0, 0);
            }
        }
        else if (isValueBetween(Mathf.Abs(enemyRigidBody.position.z), 14.9f, 15.1f) && isValueBetween(enemyRigidBody.position.x, -35.1f, -34.9f))
        {
            if (side2 == 1)
            {
                enemyRigidBody.velocity = new Vector3(0, 0, speed);
            }
            else if (side2 == 2)
            {
                enemyRigidBody.velocity = new Vector3(0, 0, -1 * speed);
            }
            else
            {
                enemyRigidBody.velocity = new Vector3(speed, 0, 0);
            }
        }
        else if (isValueBetween(Mathf.Abs(enemyRigidBody.position.z), 14.9f, 15.1f) && isValueBetween(Mathf.Abs(enemyRigidBody.position.x), 14.9f, 15.1f))
        {
            if (side == 1)
            {
                enemyRigidBody.velocity = new Vector3(0, 0, speed);
            }
            else if (side == 2)
            {
                enemyRigidBody.velocity = new Vector3(0, 0, -1 * speed);
            }
            else if (side == 3)
            {
                enemyRigidBody.velocity = new Vector3(speed, 0, 0);
            } 
            else
            {
                enemyRigidBody.velocity = new Vector3(-1*speed, 0, 0);
            }
        }
        else if (Mathf.Abs(enemyRigidBody.velocity.x) < 1 && Mathf.Abs(enemyRigidBody.velocity.z) < 1)
        {
            if (side == 1)
            {
                enemyRigidBody.velocity = new Vector3(0, 0, speed);
            }
            else if (side == 2)
            {
                enemyRigidBody.velocity = new Vector3(0, 0, -1 * speed);
            }
            else if (side == 3)
            {
                enemyRigidBody.velocity = new Vector3(speed, 0, 0);
            }
            else
            {
                enemyRigidBody.velocity = new Vector3(-1 * speed, 0, 0);
            }
        }

        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shot" && !recovering)
        {
            health -= 20;
            recovering = true;
            BlinkEnemy();
        }
        else if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player")
        {
            enemyRigidBody.velocity = collision.contacts[0].normal.normalized*speed;
        }
    }

    void BlinkEnemy()
    {
        StartCoroutine(DoBlinks(0.10f, 0.1f));
    }

    IEnumerator DoBlinks(float duration, float blinkTime)
    {
        while (duration > 0f)
        {
            duration -= Time.deltaTime;

            //toggle renderer
            rend.enabled = !rend.enabled;

            //wait for a bit
            yield return new WaitForSeconds(blinkTime);
        }

        //make sure renderer is enabled when we exit
        rend.enabled = true;
        recovering = false;
    }

    bool isValueBetween(float value, float min, float max)
    {
        return value > min && value < max;
    }

    public float getHealth()
    {
        return health;
    }
}
