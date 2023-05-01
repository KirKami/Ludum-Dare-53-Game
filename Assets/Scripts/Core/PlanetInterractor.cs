using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlanetInterractor : MonoBehaviour
{
    public List<PlanetInterractor> AIwaypoints = new List<PlanetInterractor>();

    public List<ItemEntity> itemStore = new List<ItemEntity>();
    public List<ItemEntity> itemDynamic = new List<ItemEntity>();
    public List<ItemEntity> itemProduction = new List<ItemEntity>();

    public List<TechUpgrade> upgradesStore = new List<TechUpgrade>();

    public List<SpaceshipEntity> spaceshipsDocked = new List<SpaceshipEntity>();

    public float productionTimer = 1f;

    Vector3 lastPos;

    public UnityEvent<PlanetInterractor> planetMenuCallEvent;
    public UnityEvent<PlanetInterractor> planetMenuHideEvent;

    [Serializable]
    public class TechUpgrade
    {
        public int cost;
        public int increase;
        public bool availability;
        public int limit;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.root.TryGetComponent<SpaceshipEntity>(out var targetEntity);
        if (!targetEntity) return;
        //if (targetEntity.lastDocked < 10f) return;
        if (spaceshipsDocked.Contains(targetEntity)) return;

        targetEntity.docked = true;
        spaceshipsDocked.Add(targetEntity);
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.root.TryGetComponent<SpaceshipEntity>(out var targetEntity);
        if (!targetEntity) return;
        if (!spaceshipsDocked.Contains(targetEntity)) return;

        targetEntity.docked = false;
        spaceshipsDocked.Remove(targetEntity);
        if(targetEntity.isPlayer) planetMenuHideEvent.Invoke(this);
    }
    
    private void FixedUpdate()
    {
        Vector3 positionDelta = transform.position - lastPos;

        lastPos = transform.position;

        for (int i = spaceshipsDocked.Count - 1; i >= 0; i--)
        {
            var item = spaceshipsDocked[i];
            if (item.dockedTime > 3f)
            {
                if (!item.isPlayer)
                {
                    AISellEverything(item);
                    AIBuyRandom(item);

                    item.docked = false;
                    spaceshipsDocked.Remove(item);
                    item.navMeshControl.followTarget = AIwaypoints[UnityEngine.Random.Range(0, AIwaypoints.Count)].transform;
                }
                else
                {
                    planetMenuCallEvent.Invoke(this);
                }
            }
        }

        //if(productionTimer >= 1f)
        //{
        //    productionTimer -= 1f;
        //    ProductionStep();
        //}
        //else
        //{
        //    productionTimer += Time.fixedDeltaTime;
        //}
    }

    public void SellCargo(SpaceshipEntity sellerEntity, ItemEntity sold, int quantity)
    {
        var itemInStore = itemStore.Find(item => sold.cargoType == item.cargoType);
        //var itemInStoreDynamic = itemStore.Find(item => sold.cargoType == item.cargoType);

        int totalCost = (itemInStore.cost / 2) * quantity;
        sellerEntity.moneyAvailable += totalCost;

        sold.quantity -= quantity;

        //itemInStore.cost += itemInStoreDynamic.cost * quantity;


        Debug.Log("TRANSACTION: " + sellerEntity.gameObject.name + " sold " + sold.cargoType.ToString() + " for " + totalCost.ToString());
    }
    public void BuyCargo(SpaceshipEntity buyerEntity, ItemEntity.CargoType type, int quantity)
    {
        var itemInStore = itemStore.Find(item => type == item.cargoType);
        //var itemInStoreDynamic = itemStore.Find(item => type == item.cargoType);

        buyerEntity.AddCargo(type, quantity);

        int totalCost = itemInStore.cost * quantity;
        buyerEntity.moneyAvailable -= totalCost;

        //itemInStore.cost -= itemInStoreDynamic.cost * quantity;
        //if (itemInStore.cost < 1) itemInStore.cost = 1;

        Debug.Log("TRANSACTION: " + buyerEntity.gameObject.name + " bought " + type.ToString() + " for " + totalCost.ToString());
    }

    void AISellEverything(SpaceshipEntity targetEntity)
    {
        for (int i = targetEntity.cargo.Count - 1; i >= 0; i--)
        {
            var item = targetEntity.cargo[i];

            SellCargo(targetEntity, item, item.quantity);

            //int totalCost = item.cost * item.quantity;
            //targetEntity.moneyAvailable += totalCost;

            //Debug.Log("TRANSACTION: " + targetEntity.gameObject.name + " sold " + item.cargoType.ToString() + " for " + totalCost.ToString());

            targetEntity.cargo.RemoveAt(i);
        }
    }
    void AIBuyRandom(SpaceshipEntity targetEntity)
    {
        int randomStoreItemIndex = UnityEngine.Random.Range(0, itemStore.Count);

        int budget = targetEntity.moneyAvailable / 2;

        int quantityToBuy = budget / itemStore[randomStoreItemIndex].cost;

        BuyCargo(targetEntity, itemStore[randomStoreItemIndex].cargoType, quantityToBuy);
        if (targetEntity.moneyAvailable < 500) targetEntity.moneyAvailable = 500;
    }
    void ProductionStep()
    {
        foreach (var item in itemProduction)
        {
            var itemInStore = itemStore.Find(searchItem => item.cargoType == searchItem.cargoType);

            itemInStore.quantity += item.quantity;
        }
    }
}
