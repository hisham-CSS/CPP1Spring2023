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
            

            if (currentPickup == PickupType.Powerup)
            {
                //do something;
                PlayerController myController = collision.gameObject.GetComponent<PlayerController>();
                myController.StartJumpForceChange();
                Destroy(gameObject);
                return;
            }

            if (currentPickup == PickupType.Life)
            {
                //do something;
                GameManager.Instance.Lives++;
                Destroy(gameObject);
                return;
            }

            //do something in regards to score
            GameManager.Instance.Score++;
            Destroy(gameObject);
        }
    }
}
