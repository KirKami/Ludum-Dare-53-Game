using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlanetCanvas : MonoBehaviour
{
    public PlanetInterractor planet;
    public SpaceshipEntity playerEntity;
    public Canvas canvas;

    public bool called;

    public Canvas[] menus;
    public UnityEvent callEvent;
    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;
    }

    public void ShowMenu(PlanetInterractor planet)
    {
        if (canvas.enabled) return;
        this.planet = planet;
        ShowMenu();
    }
    public void HideMenu(PlanetInterractor planet)
    {
        if (!canvas.enabled) return;
        HideMenu();
    }
    public void ShowMenu()
    {
        if (canvas.enabled || called) return;
        canvas.enabled = true;

        foreach (var item in menus)
        {
            item.enabled = false;
        }
        callEvent.Invoke();

        Time.timeScale = 0;
    }
    public void HideMenu()
    {
        if (!canvas.enabled && called) return;
        canvas.enabled = false;
        Time.timeScale = 1;
    }
    public void SetMenuCalled()
    {
        called = true;
    }
    public void ResetMenuCalled()
    {
        called = false;
    }
}
