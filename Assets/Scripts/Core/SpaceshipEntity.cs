using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipEntity : MonoBehaviour
{
    public bool isPlayer;

    public Color mainColor = Color.white;
    public MeshRenderer[] baseColorMesh;

    public NavMeshControl navMeshControl;

    public EquipmentController equipmentController;
    public SpaceshipEntity entity;
    public DamagableEntity damagable;

    public bool docked;
    public float lastDocked;
    public float dockedTime;

    public int moneyAvailable = 1000;

    public List<ItemEntity> cargo = new List<ItemEntity>();
    public CargoDrop cargoDropPrefab;

    private void Start()
    {
        SetMainColor();
    }

    public ItemEntity debugCargo;
    [EditorCools.Button]
    public void AddDebugCargo() 
    {
        cargo.Add(debugCargo);
    }
    public void AddCargo(ItemEntity.CargoType type, int quantity)
    {
        AddCargo(type, quantity, 0);
    }
    public void AddCargo(ItemEntity.CargoType type, int quantity, int cost)
    {
        var itemInCargo = cargo.Find(item => type == item.cargoType);
        if (itemInCargo == null)
        {
            ItemEntity newCargoEntity = new ItemEntity
            {
                cargoType = type,
                quantity = quantity,
                cost = cost,
            };
            cargo.Add(newCargoEntity);
        }
        else
        {
            itemInCargo.quantity += quantity;
        }
    }
    public void DropAllCargo()
    {
        for (int i = cargo.Count - 1; i >= 0; i--)
        {
            var item = cargo[i];

            var cargoDropInstance = Instantiate(cargoDropPrefab, transform.position, Quaternion.identity);
            cargoDropInstance.itemEntity = item;

            cargo.RemoveAt(i);
        }
    }
    public void SetMainColor()
    {
        foreach (var item in baseColorMesh)
        {
            item.material.color = mainColor;
        }
    }
    private void FixedUpdate()
    {
        if (docked)
        {
            dockedTime += Time.fixedDeltaTime;
            lastDocked = 0;
        }
        else
        {
            dockedTime = 0;
            lastDocked += Time.fixedDeltaTime;
        }
    }
}
