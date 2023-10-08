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

    private PlayerController player;

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

        player = FindObjectOfType<PlayerController>();
        if (player)
        {
            player.SwitchGun(weapons[0].GetComponent<GunControllerBase>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && currentWeaponIndex < totalWeapons -1)
        {
            SwitchWeapon(1);
        }

        else if (Input.GetKeyDown(KeyCode.Q) && currentWeaponIndex > 0)
        {
            SwitchWeapon(-1);
        }
    }

    private void SwitchWeapon(int direction)
    {
        weapons[currentWeaponIndex].SetActive(false);
        currentWeaponIndex += direction;
        weapons[currentWeaponIndex].SetActive(true);
        curentWeapon = weapons[currentWeaponIndex];

        if (player)
        {
            player.SwitchGun(weapons[currentWeaponIndex].GetComponent<GunControllerBase>());
        }
    }
}
