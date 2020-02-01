using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Image healthBar;
    public float maxHealth;
    
    public void setFillAmount(float health)
    {
        healthBar.fillAmount = health / maxHealth;
    }

}