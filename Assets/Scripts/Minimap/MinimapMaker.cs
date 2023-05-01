using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapMaker : MonoBehaviour
{
    [SerializeField] float scale = 1;

    GameObject[] celestials;
    GameObject[] neutrals;
    GameObject[] enemies;

    [SerializeField]
    Image celestialIconPrefab;
    [SerializeField]
    Image playerIconPrefab;
    [SerializeField]
    Image neutralIconPrefab;
    [SerializeField]
    Image enemyIconPrefab;

    List<MinimapElement> minimapIcons = new List<MinimapElement>();

    public class MinimapElement
    {
        public Image iconInstance;
        public Transform objectToSync;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        Vector3 playerScaledPos = new Vector3(player.transform.position.x / scale, player.transform.position.z / scale);
        Image playerIconInstance = Instantiate(playerIconPrefab, playerScaledPos, Quaternion.identity, transform);
        MinimapElement playerElementInstance = new MinimapElement
        {
            iconInstance = playerIconInstance,
            objectToSync = player.transform,
        };

        minimapIcons.Add(playerElementInstance);

        celestials = GameObject.FindGameObjectsWithTag("Celestial");

        neutrals = GameObject.FindGameObjectsWithTag("Spaceship");
        
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject a in celestials)
        {
            if (a.transform.position == Vector3.zero) continue;

            Vector3 scaledPos = new Vector3(a.transform.position.x / scale, a.transform.position.z / scale);
            Image celestialIconInstance = Instantiate(celestialIconPrefab, scaledPos, Quaternion.identity, transform);
            MinimapElement elementInstance = new MinimapElement
            {
                iconInstance = celestialIconInstance,
                objectToSync = a.transform,
            };
            minimapIcons.Add(elementInstance);
        }

        foreach (GameObject a in neutrals)
        {
            if (a.transform.position == Vector3.zero) continue;

            Vector3 scaledPos = new Vector3(a.transform.position.x / scale, a.transform.position.z / scale);
            Image celestialIconInstance = Instantiate(neutralIconPrefab, scaledPos, Quaternion.identity, transform);
            MinimapElement elementInstance = new MinimapElement
            {
                iconInstance = celestialIconInstance,
                objectToSync = a.transform,
            };
            minimapIcons.Add(elementInstance);
        }

        foreach (GameObject a in enemies)
        {
            if (a.transform.position == Vector3.zero) continue;

            Vector3 scaledPos = new Vector3(a.transform.position.x / scale, a.transform.position.z / scale);
            Image celestialIconInstance = Instantiate(enemyIconPrefab, scaledPos, Quaternion.identity, transform);
            MinimapElement elementInstance = new MinimapElement
            {
                iconInstance = celestialIconInstance,
                objectToSync = a.transform,
            };
            minimapIcons.Add(elementInstance);
        }
    }

    void FixedUpdate()
    {
        for (int i = minimapIcons.Count - 1; i >= 0; i--)
        {
            if (minimapIcons[i].objectToSync == null)
            {
                Destroy(minimapIcons[i].iconInstance.gameObject);
                minimapIcons.RemoveAt(i);
            }
        }
        foreach (var a in minimapIcons)
        {
            Vector3 scaledPos = new Vector3(a.objectToSync.transform.position.x / scale, a.objectToSync.transform.position.z / scale);
            a.iconInstance.rectTransform.anchoredPosition = scaledPos;
        }
    }

    public void CycleZoom()
    {
        switch (scale)
        {
            case 1:
                scale = 2;
                break;
            case 2:
                scale = 3;
                break;
            case 3:
                scale = 1;
                break;
            default:
                break;
        }
    }
}
