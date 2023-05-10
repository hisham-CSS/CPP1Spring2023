using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public enum PickupType
    {
        Powerup,
        Life,
        Score
    }

    public PickupType currentPickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController myController = collision.gameObject.GetComponent<PlayerController>();

            if (currentPickup == PickupType.Powerup)
            {
                //do something;
                myController.StartJumpForceChange();
                Destroy(gameObject);
                return;
            }

            if (currentPickup == PickupType.Life)
            {
                //do something;
                myController.lives++;
                Destroy(gameObject);
                return;
            }

            //do something in regards to score
            myController.score++;
            Destroy(gameObject);
        }
    }
}
