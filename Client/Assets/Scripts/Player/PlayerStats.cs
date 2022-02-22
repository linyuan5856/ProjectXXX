using UnityEngine;

public class PlayerStats : CharacterStats
{
    PlayerManager playerManager;
    HealthBar healthBar;
    StaminaBar staminaBar;
    PlayerAnimatorManager animatorHandler;

    public float staminaRegenerationAmount = 100f;
    public float staminaRegenTimer = 0;

    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
        animatorHandler = GetComponentInChildren<PlayerAnimatorManager>();
        healthBar = FindObjectOfType<HealthBar>();
        staminaBar = FindObjectOfType<StaminaBar>();
    }

    void Start()
    {
        maxHealth = SetMaxHealthFromHealthLevel();
        currentHealth = maxHealth;
        //Debug.Log(maxHealth);
        healthBar.SetMaxHealth(maxHealth);
      

        maxStamina = SetMaxStaminaFromStaminaLevel();
        currentStamina = maxStamina;
        staminaBar.SetMaxStramina(maxStamina);
    }

    private int SetMaxHealthFromHealthLevel()
    {
        maxHealth = healthLevel * 50;
        return maxHealth;
    }

    private float SetMaxStaminaFromStaminaLevel()
    {
        maxStamina = staminaLevel * 10;
        return maxStamina;
    }

    public void TakeDamageNoAnimation(int damage)
    {
        currentHealth = currentHealth - damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
        }
    }
    public void TakeDamage(int damage, string damageAnimation = "Damage_01")
    {
       // Debug.Log(damage);
        if (playerManager.isInvulnerable||isDead) return;
        
        currentHealth = currentHealth - damage;
        //Debug.Log(currentHealth);
        healthBar.SetCurrentHealth(currentHealth);

        animatorHandler.PlayTargetAnimation(damageAnimation, true);
        //Debug.Log("shanghai");

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            animatorHandler.PlayTargetAnimation("Dead_01", true);
            isDead = true;
        }
    }

    public void TakeStaminaDamage(int damage)
    {
        currentStamina = currentStamina - damage;
        if(currentStamina < 0)
        {
            currentStamina = 0;
        }
        staminaBar.SetCurrentStamina(currentStamina);
       // Debug.Log(currentStamina);
    }

    public void RegenerateStamina()
    {
        if (playerManager.isInteracting)
        {
            staminaRegenTimer = 0;
        }
        
        else 
        {
            staminaRegenTimer += Time.deltaTime;

            if (currentStamina < maxStamina && staminaRegenTimer > 1f)
            {
                currentStamina += staminaRegenerationAmount * Time.deltaTime * 10;
                staminaBar.SetCurrentStamina(Mathf.RoundToInt(currentStamina));
            }
        }
        
    }
   
}
