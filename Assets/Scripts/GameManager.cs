using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int Health;

    public int MaxHealth = 100;

    public int Stamina = 100;

    public bool IsStaminaRestoring = false;

    private void Start()
    {
        Health = MaxHealth;
    }

    private IEnumerator StaminaRestore()
    {
        IsStaminaRestoring = true;
        yield return new WaitForSeconds(3f);
        Stamina = 100;
        IsStaminaRestoring = false;
    }

    private void StaminaCheck()
    {
        //Debug.Log("Стамина: " + Stamina);

        if (Stamina <=0) StartCoroutine(StaminaRestore());
    }

    public void SpendStamina()
    {
        Stamina -= 1;
    }

    private void FixedUpdate()
    {
        StaminaCheck();
    }
    
    public void Healing(int HealthPoinCount)
    {
        if (Health + HealthPoinCount >= MaxHealth) Health = MaxHealth;
        else Health += HealthPoinCount;

        Debug.Log("HP: " + Health);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0) Health = 0;
        Debug.Log("Осталось здоровья: " + Health);
    }
}