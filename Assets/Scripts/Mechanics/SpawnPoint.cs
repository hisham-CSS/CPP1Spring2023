using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject[] pickups;

    private void Start()
    {
        Instantiate(pickups[Random.Range(0, pickups.Length)], transform.position, transform.rotation);
    }
}
