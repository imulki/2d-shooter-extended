using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponUpgradeManager : MonoBehaviour
{
    public bool isUpgradeChosen = false;
    private float speedUpgrade = 0.98f; // 2% increase
    private int diagonalBullets = 2; 

    PlayerShooting playerShooting;

    public void Start(){
        playerShooting = GameObject.Find("Player").GetComponentInChildren<PlayerShooting>();
    }

    public void Update(){ 

    }

    public void addWeaponSpeed(){
        playerShooting.timeBetweenBullets = playerShooting.timeBetweenBullets * speedUpgrade;
        UpgradeWeapon();
    }

    public void addWeaponBullet(){
        playerShooting.addBulletLines(diagonalBullets);
        UpgradeWeapon();
    }

    // public void addMaxHealth(){

    // }

    public void UpgradeWeapon()
    {
        Debug.Log("UPGRADE CHOSEN");
        isUpgradeChosen = true;
        // Time.timeScale = 1;
    }
}
