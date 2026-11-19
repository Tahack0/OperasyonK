using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth = 100f;
    private Animator playerAnimator;
    public Text Saglik;
    public Slider slider;
    public float healthIncreaseRate = 1f; // Saðlýk artýþ hýzý
    public float maxHealth = 100f;       // Maksimum saðlýk deðeri
    public float healthIncreaseDelay = 5f; // Hasar aldýktan sonra saðlýk artýþý için bekleme süresi

    private bool canIncreaseHealth = false; // Saðlýk artýrma kontrolü
    private Coroutine healthCoroutine;      // Coroutine referansý

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        Saglik.text = "%" + playerHealth.ToString("0");
        slider.value = playerHealth / maxHealth;
    }

    public void HesaplananHealth(float hesaplananHealth)
    {
        playerHealth -= hesaplananHealth;
        playerHealth = Mathf.Clamp(playerHealth, 0, maxHealth); // Saðlýðý sýnýrla

        if (playerHealth <= 0)
        {
            PlayerDead();
        }
        else
        {
            // Hasar alýndýðýnda saðlýk artýrma Coroutine'ýný durdur ve tekrar baþlat
            if (healthCoroutine != null)
            {
                StopCoroutine(healthCoroutine);
            }
            canIncreaseHealth = false;
            healthCoroutine = StartCoroutine(HealthIncreaseDelay());
        }
    }

    void PlayerDead()
    {
        playerAnimator.SetBool("playerdead", true);
        Destroy(gameObject, 10f);
    }

    IEnumerator HealthIncreaseDelay()
    {
        // 3 saniye bekle
        yield return new WaitForSeconds(healthIncreaseDelay);
        canIncreaseHealth = true;

        // Saðlýk artýrma iþlemi baþlasýn
        while (canIncreaseHealth && playerHealth < maxHealth)
        {
            yield return new WaitForSeconds(1f); // Her 1 saniyede bir saðlýk artýr
            playerHealth += healthIncreaseRate;
            playerHealth = Mathf.Clamp(playerHealth, 0, maxHealth);
        }
    }
}
