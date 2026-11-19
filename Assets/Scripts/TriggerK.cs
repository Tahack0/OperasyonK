using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TriggerK : MonoBehaviour
{
    public TextMeshProUGUI Trigger;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Trigger.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.tag == "Trigger1")
        {
            Trigger.text = " " + " Rehin olan askeri kurtar ve bölümü tamamla.";
        }

    }
}
