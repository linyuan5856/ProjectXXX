using UnityEngine;

public class EnemyStats : CharacterStats
{
    EnemyAnimatorManager enemyAnimatorManager;
    EnemyManager enemyManager;
    UIBossHealthBar UIBossHealthBar;

    public float staminaRegenerationAmount;
    public float staminaRegenTimer = 0;

    Animator animator;

    private void Awake()
    {
        enemyManager = GetComponent<EnemyManager>();
        animator = GetComponentInChildren<Animator>();
        UIBossHealthBar = FindObjectOfType<UIBossHealthBar>();
    }

    void Start()
    {
        maxHealth = SetMaxHealthFromHealthLevel();
        currentHealth = maxHealth;
        UIBossHealthBar.SetBossMaxHealth(maxHealth);
        maxStamina = SetMaxStaminaFromStaminaLevel();
        currentStamina = maxStamina;
    }

    private int SetMaxHealthFromHealthLevel()
    {
        maxHealth = healthLevel;
        return maxHealth;
    }

    public void TakeDamageNoAnimation(int damage)
    {
        currentHealth = currentHealth - damage;

        UIBossHealthBar.SetBossCurrentHealth(currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
        }
    }

    private float SetMaxStaminaFromStaminaLevel()
    {
        maxStamina = staminaLevel * 10;
        return maxStamina;
    }

    public void TakeStaminaDamage(int damage)
    {
        currentStamina = currentStamina - damage;
        if (currentStamina < 0)
        {
            Debug.Log(currentStamina);
            currentStamina = 0;
        }
        //staminaBar.SetCurrentStamina(currentStamina);
        // Debug.Log(currentStamina);
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
            return;

        currentHealth = currentHealth - damage;
        //Debug.Log(currentHealth);
        UIBossHealthBar.SetBossCurrentHealth(currentHealth);


        animator.Play("Damage_01");

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            animator.Play("Dead_01");
            isDead = true;
        }
    }

    public void RegenerateStamina()
    {
        if (enemyManager.isInteracting)
        {
            staminaRegenTimer = 0;
        }

        else
        {
            staminaRegenTimer += Time.deltaTime;

            if (currentStamina < maxStamina && staminaRegenTimer > 1f)
            {
                currentStamina += staminaRegenerationAmount * Time.deltaTime * 1;
                // staminaBar.SetCurrentStamina(Mathf.RoundToInt(currentStamina));
            }
        }
    }
}