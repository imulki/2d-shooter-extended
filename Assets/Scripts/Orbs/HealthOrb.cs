using UnityEngine;

public class HealthOrb : OrbObject {
    public int healthBonus = 20;
    private PlayerHealth playerHealth;

    protected override void activateOrb(){
        base.activateOrb();
        playerHealth = playerObject.GetComponent<PlayerHealth>();
        playerHealth.currentHealth += playerHealth.currentHealth < playerHealth.startingHealth ? healthBonus : 0;
        playerHealth.currentHealth = Mathf.Min(100,playerHealth.currentHealth);
        playerHealth.healthSlider.value = playerHealth.currentHealth;
        playerHealth.healthText.text = playerHealth.currentHealth.ToString();
    }
}