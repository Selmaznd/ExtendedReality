using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class HealthManager : MonoBehaviour
{
    public Slider healthBar;
    public float maxHealth = 100f;
    private float currentHealth;
    public float decayRate = 5f;

    private bool isGameOver = false;

    public GameObject gameOverUI;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    void Update()
    {
        if (isGameOver) return;

        currentHealth -= decayRate * Time.deltaTime;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over!");

        if (gameOverUI != null)
            gameOverUI.SetActive(true); // afficher le panneau

        StartCoroutine(GameOverSequence());

        //if (SceneTransitionManager.singleton != null)
        //{
        //    SceneTransitionManager.singleton.GoToScene(0);
        //}
        //else
        //{
        //    Debug.LogWarning("SceneTransitionManager singleton non trouvé !");
        //}
    }

    IEnumerator GameOverSequence()
    {
        yield return new WaitForSeconds(10f);

        if (SceneTransitionManager.singleton != null)
        {
            SceneTransitionManager.singleton.GoToScene(0);
        }
        else
        {
            Debug.LogWarning("SceneTransitionManager singleton non trouvé !");
        }
    }
}
