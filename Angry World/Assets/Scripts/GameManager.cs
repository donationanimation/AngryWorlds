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

    private int level = 1;
    private int enemyCount;
    private bool gameOver = false;

    void Awake()
    {
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
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    private void Update()
    {
        if(enemyCount > 0 && projecttilesCount == 0 && !gameOver)
        {
            countDown -= Time.deltaTime;
            if(countDown <= 0)
            {
                GameOver();
            }
        }
    }

    void OnEnable()
    {
        EventManager.StartListening("ProjecttileThrowed", ProjecttileThrowed);
        EventManager.StartListening("EnemyHitted", EnemyHitted);
    }

    void OnDisable()
    {
        EventManager.StopListening("ProjecttileThrowed", ProjecttileThrowed);
        EventManager.StopListening("EnemyHitted", EnemyHitted);
    }

    private void ProjecttileThrowed()
    {
        projecttilesCount--;
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
        level++;
        print("Level Done");
    }

    private void GameOver()
    {
        gameOver = true;
        print("GameOver");
    }

}
