using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyWalker : Enemy
{
    Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        rb = GetComponent<Rigidbody2D>();

        if (speed <= 0)
            speed = 1.0f;
    }

    private void Update()
    {
        AnimatorClipInfo[] curClips = anim.GetCurrentAnimatorClipInfo(0);

        if (curClips[0].clip.name == "Walk")
        {
            rb.velocity = sr.flipX ? new Vector2(-speed, rb.velocity.y) : new Vector2(speed, rb.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Barrier"))
            sr.flipX = !sr.flipX;
    }

    public void DestroyMyself()
    {
        Destroy(transform.parent.gameObject);
    }

    public void Squish()
    {
        anim.SetTrigger("Squish");
    }
}
