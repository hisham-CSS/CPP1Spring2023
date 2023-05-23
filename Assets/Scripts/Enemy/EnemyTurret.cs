using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shoot))]
public class EnemyTurret : Enemy
{
    public float projectileFireRate;

    Shoot shootScript;
    float timeSinceLastFire = 0.0f;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        shootScript = GetComponent<Shoot>();
        shootScript.OnProjectileSpawned.AddListener(UpdateTimeSinceLastFire);

        if (projectileFireRate <= 0.0f)
            projectileFireRate = 2.0f;
    }

    private void Update()
    {
        AnimatorClipInfo[] curClips = anim.GetCurrentAnimatorClipInfo(0);

        if (curClips[0].clip.name != "Shoot")
        {
            if (Time.time >= timeSinceLastFire + projectileFireRate)
            {
                anim.SetTrigger("Shoot");
            }
        }
    }

    public override void Death()
    {
        Destroy(gameObject);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }

    void UpdateTimeSinceLastFire()
    {
        timeSinceLastFire = Time.time;
    }

    private void OnDestroy()
    {
        shootScript.OnProjectileSpawned.RemoveListener(UpdateTimeSinceLastFire);
    }
}
