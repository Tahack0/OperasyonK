using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsChange : MonoBehaviour
{
    public GameObject[] Weapons;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach (GameObject obj in Weapons)
            {
                obj.SetActive(false);
            }
            Weapons[0].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (GameObject obj in Weapons)
            {
                obj.SetActive(false);
            }
            Weapons[1].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            foreach (GameObject obj in Weapons)
            {
                obj.SetActive(false);
            }
            Weapons[2].SetActive(true);
        }
    }
}