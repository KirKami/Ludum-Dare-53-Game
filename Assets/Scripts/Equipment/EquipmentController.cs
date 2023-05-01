using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class EquipmentController : MonoBehaviour
{
    public List<WeaponEquip> weapons = new List<WeaponEquip>();
    public List<EngineEquip> engine = new List<EngineEquip>();
    public List<EquipmentBase> auxiliary = new List<EquipmentBase>();

    public SpaceshipMovement mover;
    public Collider hurtbox;
   // public Collider collision;

    public TMPro.TMP_Text speedText;
    public UnityEngine.UI.Image speedBar;

    public void OnPrimaryWeapon(InputAction.CallbackContext context)
    {
        weapons[0].holdUseInput  = context.ReadValue<float>() > 0.5f ? true : false;
    }
    public void OnSecondaryWeapon(InputAction.CallbackContext context)
    {
        weapons[1].holdUseInput = context.ReadValue<float>() > 0.5f ? true : false;
    }

    public void UseWeapons()
    {
        foreach (var gun in weapons)
        {
            gun.UseEquipment();
        }
    }
    public void UseEngine()
    {
        foreach (var engine in engine)
        {
            engine.UseEquipment();
        }
    }

    private void Update()
    {
        if (speedText && speedBar)
        {
            var localTransformVelocity = transform.InverseTransformDirection(mover.rigid.velocity);

            speedText.text = localTransformVelocity.z.ToString();

            speedText.text = string.Format("{0:F0}", localTransformVelocity.z * 100f);

            speedBar.fillAmount = localTransformVelocity.z / (engine[0].maxMoveSpeed * engine[0].boostFactor);
            Color fadeColor = localTransformVelocity.z > engine[0].maxMoveSpeed ? engine[0].boostExhaustColor : engine[0].baseExhaustColor;
            speedBar.CrossFadeColor(fadeColor, 0.1f, true, false);
        }
    }
}
