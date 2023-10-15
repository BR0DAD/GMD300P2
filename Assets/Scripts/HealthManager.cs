using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;

    public void TakeDamage()
    {
        healthBar.fillAmount = healthAmount / 100f;
    }

}
