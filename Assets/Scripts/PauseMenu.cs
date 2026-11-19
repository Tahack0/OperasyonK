using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;      // Pause menüsü arayüzü
    public Camera menuCamera;          // Menü kamerasý
    public Camera gameCamera;          // Oyun kamerasý
    public AudioSource menuAudio;      // Menü sesi (isteðe baðlý)
    public AudioSource gameAudio;      // Oyun sesi (isteðe baðlý)
    private bool isPaused = false;

    void Start()
    {
        // Menü elemanlarýný ve seslerini baþlangýçta devre dýþý býrak
        if (pauseMenuUI != null) pauseMenuUI.SetActive(false);
        if (menuCamera != null) menuCamera.gameObject.SetActive(false);
        if (menuAudio != null) menuAudio.Stop();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        if (pauseMenuUI != null) pauseMenuUI.SetActive(false);  // Menü arayüzünü gizle
        if (menuCamera != null) menuCamera.gameObject.SetActive(false);  // Menü kamerasýný kapat
        if (menuAudio != null) menuAudio.Stop();  // Menü sesini durdur
        if (gameAudio != null) gameAudio.Play();  // Oyun sesini baþlat
        if (gameCamera != null) gameCamera.gameObject.SetActive(true);  // Oyun kamerasýný aç

        Time.timeScale = 1f;  // Zamaný devam ettir
        isPaused = false;
    }

    void Pause()
    {
        if (pauseMenuUI != null) pauseMenuUI.SetActive(true);  // Menü arayüzünü göster
        if (menuCamera != null) menuCamera.gameObject.SetActive(true);  // Menü kamerasýný aç
        if (menuAudio != null) menuAudio.Play();  // Menü sesini baþlat
        if (gameAudio != null) gameAudio.Pause();  // Oyun sesini duraklat
        if (gameCamera != null) gameCamera.gameObject.SetActive(false);  // Oyun kamerasýný kapat

        Time.timeScale = 0f;  // Zamaný durdur
        isPaused = true;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;  // Zamaný sýfýrla
        SceneManager.LoadScene("MainMenu");  // Ana menü sahnesini yükle
    }

    public void QuitGame()
    {
        Application.Quit();  // Oyunu kapat
        Debug.Log("Oyun kapatýldý!");
    }
}
