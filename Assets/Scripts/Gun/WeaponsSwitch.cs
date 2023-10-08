using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsSwitch : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;
    [SerializeField] GameObject weaponHolder;
    [SerializeField] GameObject curentWeapon;

    private int currentWeaponIndex;

    private int totalWeapons = 1;

    // Start is called before the first frame update
    void Start()
    {
        totalWeapons = weaponHolder.transform.childCount;
        weapons = new GameObject[totalWeapons];

        for(int i = 0; i < totalWeapons; i++)
        {
            weapons[i] = weaponHolder.transform.GetChild(i).gameObject;
            weapons[i].SetActive(false);
        }

        weapons[0].SetActive(true);
        curentWeapon = weapons[0];
        currentWeaponIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(currentWeaponIndex < totalWeapons - 1)
            {
                weapons[currentWeaponIndex].SetActive(false);
                currentWeaponIndex++;
                weapons[currentWeaponIndex].SetActive(true);
                curentWeapon = weapons[currentWeaponIndex];
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentWeaponIndex > 0)
            {
                weapons[currentWeaponIndex].SetActive(false);
                currentWeaponIndex--;
                weapons[currentWeaponIndex].SetActive(true);
                curentWeapon = weapons[currentWeaponIndex];
            }
        }
    }
}
