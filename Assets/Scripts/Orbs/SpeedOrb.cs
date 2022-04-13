using UnityEngine;

public class SpeedOrb : OrbObject {
    public float speedBonus = 1f;
    private PlayerMovement playerMovement;

    protected override void activateOrb(){
        base.activateOrb();
        playerMovement = playerObject.GetComponent<PlayerMovement>();
        playerMovement.speed += playerMovement.speed < playerMovement.maxSpeed ? speedBonus : 0;
        playerMovement.speedText.text = playerMovement.speed.ToString();
    }
}