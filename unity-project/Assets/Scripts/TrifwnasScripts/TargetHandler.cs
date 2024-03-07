using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetHandler : MonoBehaviour
{
    [SerializeField]  float health, maxHealth = 3f;
    private float criticalHealth;
    private Renderer rendere;
    private Material targetMaterial;
    private bool isTargetActive;
    internal Vector3 position;

    public HealthBar healthbar; // Tony Added

    private void Start()
    {
        health = maxHealth;
        criticalHealth = maxHealth / 5;
        rendere = GetComponent<Renderer>();
        isTargetActive = true;

        healthbar.SetMaxHealthOnSlider(maxHealth); // Tony Added
    }

    

    public void gotHit(float damageAmount)
    {
        health -= damageAmount;
        healthbar.SetHealthOnSlider(health); // Tony Added
        if (health<=0)
        {
            Destroy(gameObject);
            isTargetActive = false;
        }
    }

    public bool isActive()
    {
        return isTargetActive;
    }

    public void Update()
    {
        if (health <= criticalHealth) 
        {
            rendere.material.color = Color.red;
        }
    }
}
