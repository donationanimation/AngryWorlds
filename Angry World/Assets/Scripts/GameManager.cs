using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Sound[] sounds;
    public int projecttilesCount;
    public float countDown = 10.0f;
    public GameObject ballPrefap;
    public GameObject ball;

    private LineRenderer front;
    private LineRenderer back;
    private Vector2 startPosition;
    private int level = 1;
    public int enemyCount;
    private bool gameOver = false;
    private bool isThrowed = false;
    private Vector2 connectedAnchor;
    private Rigidbody2D connectedBody;
    private float distance;
    private float frequency;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }

    }

    private void Start()
    {
        startPosition = ballPrefap.transform.position;
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        connectedAnchor = ball.GetComponent<SpringJoint2D>().connectedAnchor;
        connectedBody = ball.GetComponent<SpringJoint2D>().connectedBody;
        distance = ball.GetComponent<SpringJoint2D>().distance;
        frequency = ball.GetComponent<SpringJoint2D>().frequency;
        back = ball.GetComponent<ProjectileDragging>().catapultLineBack;
        front = ball.GetComponent<ProjectileDragging>().catapultLineFront;
    }

    private void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount > 0 && projecttilesCount == 0 && !gameOver)
        {
            countDown -= Time.deltaTime;
            if(countDown <= 0)
            {
                GameOver();
            }
        }else if (isThrowed && enemyCount > 0)
        {
            countDown -= Time.deltaTime;
            if(countDown <= 0)
            {
                SpawnBall();
            }
        }
    }

    void OnEnable()
    {
        EventManager.StartListening("ProjecttileThrowed", ProjecttileThrowed);
        EventManager.StartListening("EnemyHitted", EnemyHitted);
        EventManager.StartListening("NextLevel", NextLevel);
    }

    void OnDisable()
    {
        EventManager.StopListening("ProjecttileThrowed", ProjecttileThrowed);
        EventManager.StopListening("EnemyHitted", EnemyHitted);
        EventManager.StopListening("NextLevel", NextLevel);
    }

    private void ProjecttileThrowed()
    {
        isThrowed = true;
        projecttilesCount--;
    }

    private void SpawnBall()
    {
        if (projecttilesCount > 0)
        {
            countDown = 10.0f;
            isThrowed = false;

            ballPrefap.transform.position = startPosition;
            ballPrefap.GetComponent<Rigidbody2D>().isKinematic = true;
            ballPrefap.GetComponent<SpringJoint2D>().connectedAnchor = connectedAnchor;
            ballPrefap.GetComponent<SpringJoint2D>().connectedBody = connectedBody;
            ballPrefap.GetComponent<SpringJoint2D>().distance = distance;
            ballPrefap.GetComponent<SpringJoint2D>().frequency = frequency;
            ballPrefap.GetComponent<SpringJoint2D>().autoConfigureDistance = false;
            ballPrefap.GetComponent<ProjectileDragging>().catapultLineBack = back;
            ballPrefap.GetComponent<ProjectileDragging>().catapultLineFront= front;

            Instantiate(ballPrefap);
        }
    }

    private void EnemyHitted()
    {
        enemyCount--;
        if (enemyCount == 0)
        {
            LevelDone();
        }
    }

    private void LevelDone()
    {
        if (level == 1)
        {
            EventManager.TriggerEvent("showMessagePanelPlastic");
        }
        else if (level == 2)
        {
            EventManager.TriggerEvent("showMessagePanelAtomCanister");
        }
        else if (level == 3)
        {
            EventManager.TriggerEvent("showMessagePanelTrump");
        }
    }

    private void NextLevel()
    {
        level++;
        SceneManager.LoadScene(level - 1);
        countDown = 10.0f;
        isThrowed = false;
        projecttilesCount = 3;
        SpawnBall();
    }

    private void GameOver()
    {
        gameOver = true;
        print("GameOver");
    }

}
