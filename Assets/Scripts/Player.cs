using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody playerRB;
    public Joystick joystick;
    private float health = 100f;
    private Renderer rend;
    private bool recovering = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.Horizontal >= .2f || joystick.Horizontal <= -.2f)
        {
            playerRB.velocity = new Vector3(joystick.Horizontal * speed, playerRB.velocity.y, joystick.Vertical * speed);
        } else if (joystick.Vertical >= .2f || joystick.Vertical <= -.2f)
        {
            playerRB.velocity = new Vector3(joystick.Horizontal * speed, playerRB.velocity.y, joystick.Vertical * speed);
        } else
        {
            playerRB.velocity = new Vector3(0, 0, 0);
        }

        if (health == 0)
        {
            FindObjectOfType<GameController>().EndGame(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Shot" && !recovering)
        {
            health -= 20;
            recovering = true;
            BlinkPlayer();
        }
    }

    void BlinkPlayer()
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

    public float getHealth()
    {
        return health;
    }
}
