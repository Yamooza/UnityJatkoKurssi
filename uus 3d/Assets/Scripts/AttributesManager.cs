using UnityEngine;
using System.Collections;

public class AttributesManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int curHealth = 100;
    public int attack;

    public float healthBarLength;

    // Use this for initialization
    void Start()
    {
        healthBarLength = Screen.width / 2;
    }

    // Update is called once per frame
    void Update()
    {
        AddjustCurrentHealth(0);
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 40, healthBarLength, 20), curHealth + "/" + maxHealth);
    }
    public void TakeDamage(int amount)
    {
        curHealth -= amount;
    }
    public void DealDamage(GameObject target)
    {
        var atm = target.GetComponent<AttributesManager>();
        if(atm != null) 
        {
            atm.TakeDamage(attack);
        }
    }

    public void AddjustCurrentHealth(int adj)
    {
        curHealth += adj;

        if (curHealth < 0)
            curHealth = 0;

        if (curHealth > maxHealth)
            curHealth = maxHealth;

        if (maxHealth < 1)
            maxHealth = 1;

        if (curHealth <= 0)
        {
            Destroy(gameObject);
        }

        healthBarLength = (Screen.width / 4) * (curHealth / (float)maxHealth);
    }
}