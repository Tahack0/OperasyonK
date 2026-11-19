using UnityEngine;
using UnityEngine.SceneManagement;


public class level_change : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public string scnename;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(scnename);
        }

    }


}
