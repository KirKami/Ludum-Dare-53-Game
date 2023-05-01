using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TradeMenu : MonoBehaviour
{
    public PlanetCanvas planetCanvas;

    public TMP_Text playerMoney;

    public TMP_Text[] quantityText;
    public TMP_Text[] CostText;

    public Button[] buyButtons;
    public Button[] sellButtons;

    public void UpdateMenu()
    {
        var AInCargo = planetCanvas.playerEntity.cargo.Find(item => item.cargoType == ItemEntity.CargoType.testA);
        var BInCargo = planetCanvas.playerEntity.cargo.Find(item => item.cargoType == ItemEntity.CargoType.testB);

        var AInStore = planetCanvas.planet.itemStore.Find(item => item.cargoType == ItemEntity.CargoType.testA);
        var BInStore = planetCanvas.planet.itemStore.Find(item => item.cargoType == ItemEntity.CargoType.testB);

        quantityText[0].text = AInCargo != null ? AInCargo.quantity.ToString() : "0";
        quantityText[1].text = BInCargo != null ? BInCargo.quantity.ToString() : "0";

        CostText[0].text = AInStore != null ? AInStore.cost.ToString() + "$" : "N/A";
        CostText[1].text = BInStore != null ? BInStore.cost.ToString() + "$" : "N/A";

        bool canBuyA = AInStore != null ? planetCanvas.playerEntity.moneyAvailable >= AInStore.cost * 10 : false;
        bool canBuyB = BInStore != null ? planetCanvas.playerEntity.moneyAvailable >= BInStore.cost * 10 : false;

        buyButtons[0].interactable = canBuyA;
        buyButtons[1].interactable = canBuyB;

        bool canSellA = AInCargo != null ? AInCargo.quantity >= 10 : false;
        bool canSellB = BInCargo != null ? BInCargo.quantity >= 10 : false;

        sellButtons[0].interactable = canSellA;
        sellButtons[1].interactable = canSellB;

        playerMoney.text = planetCanvas.playerEntity.moneyAvailable.ToString();
    }

    public void BuyTestA()
    {
        planetCanvas.planet.BuyCargo(planetCanvas.playerEntity, ItemEntity.CargoType.testA, 10);
    }
    public void BuyTestB()
    {
        planetCanvas.planet.BuyCargo(planetCanvas.playerEntity, ItemEntity.CargoType.testB, 10);
    }
    public void SellTestA()
    {
        var itemInCargo = planetCanvas.playerEntity.cargo.Find(item => item.cargoType == ItemEntity.CargoType.testA);
        planetCanvas.planet.SellCargo(planetCanvas.playerEntity, itemInCargo, 10);
    }
    public void SellTestB()
    {
        var itemInCargo = planetCanvas.playerEntity.cargo.Find(item => item.cargoType == ItemEntity.CargoType.testB);
        planetCanvas.planet.SellCargo(planetCanvas.playerEntity, itemInCargo, 10);
    }
}
