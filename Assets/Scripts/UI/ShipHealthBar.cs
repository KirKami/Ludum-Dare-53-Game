using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShipHealthBar : MonoBehaviour
{
    public Image barFill;
    public TMP_Text text;

    private void Update()
    {
        transform.rotation = Quaternion.identity;
    }
    public void UpdateBar(DamagableEntity sourceEntity)
    {
        barFill.fillAmount = (float)sourceEntity.health / (float)sourceEntity.maxHealth;
        text.text = sourceEntity.health.ToString() + "/" + sourceEntity.maxHealth.ToString();
    }
}
