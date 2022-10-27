using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public class HealthBar : MonoBehaviour
    {
        public Image bar;
        internal float maxHealth;
        
        public void HealthUpdate(float currentHealth)
        { 
            bar.fillAmount = currentHealth / maxHealth ;
        }
    }
}
