using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image foregroundImage;
    [SerializeField] private Image backgroundImage;
    
    public void updateHealthBar(float health, float maxHealth)
    {
        if(health <= 0)
        {
            backgroundImage.enabled = false;
        }
        foregroundImage.fillAmount = health / maxHealth;
    }

    void Update()
    {
        backgroundImage.transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
    }
}
