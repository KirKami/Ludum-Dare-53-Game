using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNestTrigger : MonoBehaviour
{
    public EnemyNavMeshControl enemyAIprefab;
    [Range(1, 5)]
    public int nestEnemyCount = 3;

    [Range(30,500)]
    public int health = 50;
    [Range(0, 5)]
    public int armor;
    [Range(1, 15)]
    public int damage = 1;
    [Range(0.2f, 1f)]
    public float attackSpeed = 0.5f;

    public bool randomParams;

    public List<EnemyNavMeshControl> enemyAI = new List<EnemyNavMeshControl>();
    public SphereCollider trigger;

    private void Start()
    {
        if (randomParams)
        {
            nestEnemyCount = Random.Range(1, 6);
            health = Random.Range(30, 501);
            armor = Random.Range(0, 6);
            damage = Random.Range(1, 16);
            attackSpeed = Random.Range(0.2f, 1f);
        }

        foreach (var item in enemyAI)
        {
            item.transform.parent = null;
        }

        for (int i = 0; i < nestEnemyCount; i++)
        {
            Vector3 randomPos = transform.position + (Random.insideUnitSphere * trigger.radius/2);
            randomPos.y = 0;
            var enemyInstance = Instantiate(enemyAIprefab, randomPos, Quaternion.identity);
            enemyInstance.damagable.maxHealth = health;
            enemyInstance.damagable.health = health;
            enemyInstance.damagable.damageAbsorb = armor;
            enemyInstance.equipmentController.weapons[0].baseDamage = damage;
            enemyInstance.equipmentController.weapons[0].useInterval = attackSpeed;
            enemyAI.Add(enemyInstance);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        other.transform.root.TryGetComponent<SpaceshipEntity>(out var targetEntity);
        if (!targetEntity) return;
        if (!targetEntity.isPlayer) return;

        SetAIPursuitTarget(targetEntity.transform);
    }
    public void SetAIPursuitTarget(Transform target)
    {
        foreach (var item in enemyAI)
        {
            item.followTarget = target;
        }
    }
}
