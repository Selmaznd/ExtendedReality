using UnityEngine;
using UnityEngine.UI;

public class RightFillBar : MonoBehaviour
{
    public HealthManager healthManager; // ton script qui contient MaxHealth et CurrentHealth
    public RectTransform barTransform;  // le RectTransform à réduire (la barre visuelle)

    private void Update()
    {
        float ratio = Mathf.Clamp01((float)healthManager.currentHealth / healthManager.maxHealth);
        barTransform.localScale = new Vector3(ratio, 1f, 1f);
    }
}
