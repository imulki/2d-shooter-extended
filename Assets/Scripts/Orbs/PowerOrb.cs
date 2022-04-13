using UnityEngine;

public class PowerOrb : OrbObject {
    public int damageBonus = 4; 
    private PlayerShooting playerShooting;

    protected override void activateOrb(){
        base.activateOrb();
        playerShooting = playerObject.GetComponentInChildren<PlayerShooting>();
        playerShooting.damagePerShot += playerShooting.damagePerShot < playerShooting.maxDamage ? damageBonus : 0;
        playerShooting.damageText.text = playerShooting.damagePerShot.ToString();
    }
}