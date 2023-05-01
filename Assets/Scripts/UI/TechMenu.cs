using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TechMenu : MonoBehaviour
{
    public PlanetCanvas planetCanvas;

    public Countdown countdown;

    public TMP_Text playerMoney;

    public GameObject[] menuElements;

    public TMP_Text[] statText;
    public TMP_Text[] costText;

    public Button[] buyButtons;
    public Button repairButton;

    public void UpdateMenu()
    {
        playerMoney.text = planetCanvas.playerEntity.moneyAvailable.ToString();

        //Upgrade Costs
        //Hull and Armor
        costText[0].text = planetCanvas.planet.upgradesStore[0].cost.ToString() + "$";
        costText[1].text = planetCanvas.planet.upgradesStore[1].cost.ToString() + "$";
        //Weapon A
        costText[2].text = planetCanvas.planet.upgradesStore[2].cost.ToString() + "$";
        costText[3].text = planetCanvas.planet.upgradesStore[3].cost.ToString() + "$";
        //Weapon B
        costText[4].text = planetCanvas.planet.upgradesStore[4].cost.ToString() + "$";
        costText[5].text = planetCanvas.planet.upgradesStore[5].cost.ToString() + "$";
        //Speed
        costText[6].text = planetCanvas.planet.upgradesStore[6].cost.ToString() + "$";
        //Drive
        costText[7].text = planetCanvas.planet.upgradesStore[7].cost.ToString() + "$";

        //Stats Display
        //Hull and Armor
        statText[0].text = planetCanvas.playerEntity.damagable.maxHealth.ToString() + "+" + planetCanvas.planet.upgradesStore[0].increase.ToString();
        statText[1].text = planetCanvas.playerEntity.damagable.damageAbsorb.ToString() + "+" + planetCanvas.planet.upgradesStore[1].increase.ToString();
        //Weapon A
        statText[2].text = planetCanvas.playerEntity.equipmentController.weapons[0].baseDamage.ToString() + "+" + planetCanvas.planet.upgradesStore[2].increase.ToString();
        statText[3].text = (int)(planetCanvas.playerEntity.equipmentController.weapons[0].useInterval * 100) + "+" + planetCanvas.planet.upgradesStore[3].increase.ToString();
        //Weapon B
        statText[4].text = planetCanvas.playerEntity.equipmentController.weapons[1].baseDamage.ToString() + "+" + planetCanvas.planet.upgradesStore[4].increase.ToString();
        statText[5].text = (int)(planetCanvas.playerEntity.equipmentController.weapons[1].useInterval * 100) + "+" + planetCanvas.planet.upgradesStore[5].increase.ToString();
        //Speed
        statText[6].text = (int)(planetCanvas.playerEntity.equipmentController.engine[0].maxMoveSpeed * 100) + "+" + planetCanvas.planet.upgradesStore[6].increase.ToString();
        //Drive
        statText[7].text = countdown.hyperdriveState ? "Ready" : "Error";

        //Buy Buttons
        //Hull and Armor
        buyButtons[0].interactable = planetCanvas.planet.upgradesStore[0].cost <= planetCanvas.playerEntity.moneyAvailable;
        buyButtons[1].interactable = planetCanvas.planet.upgradesStore[1].cost <= planetCanvas.playerEntity.moneyAvailable;
        //Weapon A
        buyButtons[2].interactable = planetCanvas.planet.upgradesStore[2].cost <= planetCanvas.playerEntity.moneyAvailable;
        buyButtons[3].interactable = planetCanvas.planet.upgradesStore[3].cost <= planetCanvas.playerEntity.moneyAvailable;
        //Weapon B
        buyButtons[4].interactable = planetCanvas.planet.upgradesStore[4].cost <= planetCanvas.playerEntity.moneyAvailable;
        buyButtons[5].interactable = planetCanvas.planet.upgradesStore[5].cost <= planetCanvas.playerEntity.moneyAvailable;
        //Speed
        buyButtons[6].interactable = planetCanvas.planet.upgradesStore[6].cost <= planetCanvas.playerEntity.moneyAvailable;
        //Drive
        buyButtons[7].interactable = planetCanvas.planet.upgradesStore[7].cost <= planetCanvas.playerEntity.moneyAvailable && !countdown.hyperdriveState;

        for (int i = 0; i < menuElements.Length; i++)
        {
            menuElements[i].SetActive(planetCanvas.planet.upgradesStore[i].availability);
        }

        int healthDifference = planetCanvas.playerEntity.damagable.maxHealth - planetCanvas.playerEntity.damagable.health;
        repairButton.interactable = healthDifference * 1 <= planetCanvas.playerEntity.moneyAvailable;
    }
    public void BuyUpgrade(int type)
    {
        switch (type)
        {
            case 0:
                planetCanvas.playerEntity.damagable.maxHealth +=  planetCanvas.planet.upgradesStore[0].increase;
                planetCanvas.playerEntity.damagable.health += planetCanvas.planet.upgradesStore[0].increase;

                planetCanvas.playerEntity.moneyAvailable -= planetCanvas.planet.upgradesStore[0].cost;
                break;
            case 1:
                planetCanvas.playerEntity.damagable.damageAbsorb += planetCanvas.planet.upgradesStore[1].increase;

                planetCanvas.playerEntity.moneyAvailable -= planetCanvas.planet.upgradesStore[1].cost;
                break;

            case 2:
                planetCanvas.playerEntity.equipmentController.weapons[0].baseDamage += planetCanvas.planet.upgradesStore[2].increase;

                planetCanvas.playerEntity.moneyAvailable -= planetCanvas.planet.upgradesStore[2].cost;
                break;
            case 3:
                float incrementA = planetCanvas.planet.upgradesStore[3].increase * 0.01f;
                planetCanvas.playerEntity.equipmentController.weapons[0].useInterval += incrementA;

                planetCanvas.playerEntity.moneyAvailable -= planetCanvas.planet.upgradesStore[3].cost;
                break;

            case 4:
                planetCanvas.playerEntity.equipmentController.weapons[1].baseDamage += planetCanvas.planet.upgradesStore[4].increase;

                planetCanvas.playerEntity.moneyAvailable -= planetCanvas.planet.upgradesStore[4].cost;
                break;
            case 5:
                float incrementB = planetCanvas.planet.upgradesStore[5].increase * 0.01f;
                planetCanvas.playerEntity.equipmentController.weapons[1].useInterval += incrementB;

                planetCanvas.playerEntity.moneyAvailable -= planetCanvas.planet.upgradesStore[5].cost;
                break;

            case 6:
                float incrementS = planetCanvas.planet.upgradesStore[6].increase * 0.01f;
                planetCanvas.playerEntity.equipmentController.engine[0].maxMoveSpeed += incrementS;

                planetCanvas.playerEntity.moneyAvailable -= planetCanvas.planet.upgradesStore[6].cost;
                break;

            case 7:
                countdown.hyperdriveState = true;

                planetCanvas.playerEntity.moneyAvailable -= planetCanvas.planet.upgradesStore[7].cost;
                break;
            default:
                break;
        }
        UpdateMenu();
    }
}
