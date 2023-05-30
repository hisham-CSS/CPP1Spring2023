using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    static GameManager _instance = null;
    public static GameManager Instance
    {
        get => _instance;
        set
        {
            _instance = value;
        }
    }

    public int Lives
    {
        get => _lives;
        set
        {
            if (_lives > value) Respawn();

            _lives = value;
            
            if (_lives > maxLives) _lives = maxLives;

            Debug.Log("Lives value has changed to " + _lives.ToString());
            if (_lives <= 0) GameOver();
        }
    }
    private int _lives = 3;
    public int maxLives = 3;

    public int Score
    {
        get => _score;
        set
        {
            _score = value;

            Debug.Log("Score value has changed to " + _score.ToString());
        }
    }
    private int _score = 0;

    public PlayerController playerPrefab;
    [HideInInspector] public PlayerController playerInstance;
    [HideInInspector] public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance)
            Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "Level")
                SceneManager.LoadScene("Title");
            else
                SceneManager.LoadScene("Level");
        }
    }

    public void SpawnPlayer(Transform spawnLocation)
    {
        playerInstance = Instantiate(playerPrefab, spawnLocation.position, spawnLocation.rotation);
        UpdateSpawnPoint(spawnLocation);
    }

    public void UpdateSpawnPoint(Transform updatedPoint)
    {
        spawnPoint = updatedPoint;
    }

    void GameOver()
    {
        //go to game over scene
    }

    void Respawn()
    {
        playerInstance.transform.position = spawnPoint.position;
    }
}
