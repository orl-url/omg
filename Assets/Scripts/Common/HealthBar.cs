using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public class HealthBar : MonoBehaviour
    {
        public Image bar;
        
        public void HealthUpdate(float currentHealth)
        { 
            bar.fillAmount = currentHealth;
        }
    }
}
