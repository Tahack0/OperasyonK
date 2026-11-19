using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Tetikleyici : MonoBehaviour
{
    public TextMeshProUGUI Trigger;

    private void Start()
    {
        Trigger.text = "Ýlerle";
    }
     
    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.tag == "Trigger1")
        {
            Trigger.text = "W,A,S,D ile hareket et \n Sað týk ile niþan al \n Space ile zýpla \n LeftCtrl ile çömel ve LeftShift ile hýzlý koþ";
            

        }
        if (this.gameObject.tag == "Trigger2")
        {
            Trigger.text = "Tutorialý bitirmek için tüm düþmanlarý öldür";
        }
        if(this.gameObject.tag == "Trigger3")
        {
            Trigger.text = "E ile yerdeki mermileri topla";
        }

        if( this.gameObject.tag == "Trigger4")
        {
            Trigger.text = "Son düþmaný öldürdükten sonra kapýdan \n oyunun hikayesine geçebilirsin  ";
        }
    }
}