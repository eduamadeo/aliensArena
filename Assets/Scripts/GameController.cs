using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject enemyPrefab;
    public GameObject textDisplay;
    private GameObject enemy1;
    private GameObject enemy2;
    private GameObject enemy3;
    private GameObject player;
    public int secondsLeft = 90;
    public bool takingAway = false;
    public GameObject gameOverUI;
    private bool gameOver = false;

    private float barDisplayPlayer = 0;
    private float barDisplayEnemy1 = 0;
    private float barDisplayEnemy2 = 0;
    private float barDisplayEnemy3 = 0;
    public HealthBarPlayer healthBarPlayer;
    public HealthBarEnemy1 healthBarEnemy1;
    public HealthBarEnemy2 healthBarEnemy2;
    public HealthBarEnemy3 healthBarEnemy3;

    public Material enemy1Mat;
    public Material enemy2Mat;
    public Material enemy3Mat;

    string gameId = "3498471";
    bool testMode = true;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;

        Quaternion angle = Quaternion.Euler(0, 0, 0);
        player = GameObject.Find("ufo");
        angle = Quaternion.Euler(0, 90, 0);
        enemy1 = Instantiate(enemyPrefab, new Vector3(35,0,-25), angle);
        angle = Quaternion.Euler(0, 180, 0);
        enemy2 = Instantiate(enemyPrefab, new Vector3(-25, 0, -35), angle);
        angle = Quaternion.Euler(0, 270, 0);
        enemy3 = Instantiate(enemyPrefab, new Vector3(-35, 0, 25), angle);

        enemy1.GetComponent<Renderer>().material = enemy1Mat;
        enemy2.GetComponent<Renderer>().material = enemy2Mat;
        enemy3.GetComponent<Renderer>().material = enemy3Mat;

        textDisplay.GetComponent<Text>().text = "01:30";
        barDisplayPlayer = 1;
        healthBarPlayer.SetHealth(barDisplayPlayer);
        barDisplayEnemy1 = 1;
        healthBarEnemy1.SetHealth(barDisplayEnemy1);
        barDisplayEnemy2 = 1;
        healthBarEnemy2.SetHealth(barDisplayEnemy2);
        barDisplayEnemy3 = 1;
        healthBarEnemy3.SetHealth(barDisplayEnemy3);

        Advertisement.Initialize(gameId, testMode);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            if (takingAway == false && secondsLeft > 0)
            {
                StartCoroutine(TimerTake());
            }

            if (player != null)
            {
                barDisplayPlayer = player.GetComponent<Player>().getHealth() / 100;
                healthBarPlayer.SetHealth(barDisplayPlayer);
            }
            if (enemy1 != null)
            {
                barDisplayEnemy1 = enemy1.GetComponent<Enemy>().getHealth() / 100;
                healthBarEnemy1.SetHealth(barDisplayEnemy1);
            }
            if (enemy2 != null)
            {
                barDisplayEnemy2 = enemy2.GetComponent<Enemy>().getHealth() / 100;
                healthBarEnemy2.SetHealth(barDisplayEnemy2);
            }
            if (enemy3 != null)
            {
                barDisplayEnemy3 = enemy3.GetComponent<Enemy>().getHealth() / 100;
                healthBarEnemy3.SetHealth(barDisplayEnemy3);
            }

            if (barDisplayEnemy1 == 0 && barDisplayEnemy2 == 0 && barDisplayEnemy3 == 0)
            {
                gameOver = true;
                EndGame(true);
            }
        }
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if (secondsLeft > 59) {
            if (secondsLeft - 60 < 10)
            {
                textDisplay.GetComponent<Text>().text = "01:0" + (secondsLeft - 60);
            } else
            {
                textDisplay.GetComponent<Text>().text = "01:" + (secondsLeft - 60);
            }
        } else
        {
            if (secondsLeft < 10)
            {
                textDisplay.GetComponent<Text>().text = "00:0" + secondsLeft;
            } else
            {
                textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
            }
        }
        takingAway = false;
        if(secondsLeft == 0)
        {
            gameOver = true;
            EndGame(false);
        }
    }

    public void EndGame(bool won)
    {
        if (won) {
            gameOverUI.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Você ganhou";
        } else
        {
            gameOverUI.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Você perdeu";
        }
        Advertisement.Show("video");
        gameOverUI.SetActive(true);
    }
}
