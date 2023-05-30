using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int StartingLives = 2;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.SpawnPlayer(spawnPoint);
        GameManager.Instance.Lives = StartingLives;
    }
}
