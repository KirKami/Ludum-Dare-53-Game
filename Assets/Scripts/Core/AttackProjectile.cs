using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackProjectile : MonoBehaviour
{
    public WeaponEquip shooter;

    public Rigidbody rigid;
    public Collider coll;
    public float timeToLive;

    public ParticleSystem hitParticles;

    public bool destroyOnCollision;

    // Start is called before the first frame update
    void Start()
    {
        rigid.AddRelativeForce(new Vector3(0, 0, shooter.shootForce), ForceMode.Impulse);
        //Physics.IgnoreCollision(coll, shooter.controller.hurtbox);
        Destroy(gameObject, timeToLive);
    }
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.TryGetComponent<Hitbox>(out var targetEntity);
        if (!targetEntity) return;
        if (targetEntity.transform.root == shooter.transform.root) return;

        targetEntity.ApplyDamage(shooter.baseDamage);
        Instantiate(hitParticles, collision.GetContact(0).point, Quaternion.identity);
        if (destroyOnCollision) Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.TryGetComponent<Hitbox>(out var targetEntity);
        if (!targetEntity) return;
        if (targetEntity.transform.root == shooter.transform.root) return;

        targetEntity.ApplyDamage(shooter.baseDamage);
    }
}
