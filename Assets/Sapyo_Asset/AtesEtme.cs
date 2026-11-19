using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;
using UnityEngine.SceneManagement;

public class AtesEtme : MonoBehaviour
{
    RaycastHit hit;
    public GameObject MermiCikisNoktasi;
    public GameObject uzaklik;
    public bool AtesEdebilir;
    float GunTimer;
    public float TaramaHizi;
    public ParticleSystem MuzzleFlash;
    AudioSource SesKaynak;
    public AudioClip AtesSesi;
    public AudioClip ReloadSound;
    public float Menzil;
    public GeriTepme recoil;
    public GameObject mermiefekti;
    public GameObject kanefekti;
    public float mermi;
    public float sarjor;
    public float tasinanmermi;
    float eklenenmermi;
    float reloadTimer;
    public Text MermiSayac;
    public float damageenemy;
    // Start is called before the first frame update
    void Start()
    {
        SesKaynak = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(uzaklik.transform.position, uzaklik.transform.forward, out hit, 4f))
            if (hit.transform.tag == "Rehin")
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    SceneManager.LoadScene("Demo1");
                }
            }

        if (Physics.Raycast(uzaklik.transform.position, uzaklik.transform.forward, out hit, 4f))
            if(hit.transform.tag == "Ammo")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(hit.transform.gameObject);
                    tasinanmermi += 40;
                }
            }
        MermiSayac.text = "" + mermi + " / " + tasinanmermi;
        eklenenmermi = sarjor - mermi;

        if(eklenenmermi > tasinanmermi)
        {
            eklenenmermi = tasinanmermi;
        }

        if(Input.GetKeyDown(KeyCode.R) && eklenenmermi > 0 && tasinanmermi > 0)
            if(Time.time > reloadTimer)
            {   
                SesKaynak.clip = ReloadSound;
                SesKaynak.Play();
                StartCoroutine(Reload());
                reloadTimer = Time.time;
                
            }

        if (Input.GetKey(KeyCode.Mouse0) && AtesEdebilir == true && Time.time > GunTimer && mermi > 0)
        {
            Fire();
            GunTimer = Time.time + TaramaHizi;
            recoil.Fire();

            if (hit.transform.tag == "enemy")
            {
                Instantiate(kanefekti, hit.point, Quaternion.LookRotation(hit.normal));

            }
            if (hit.transform.tag == "Untagged")
            {
                Instantiate(mermiefekti, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
    }

    void Fire()
    {
        if(mermi <= 0)
        {
            AtesEdebilir = false;
        }

        if(mermi > 0)
        {
            AtesEdebilir = true;
            mermi--;
        }

        if (Physics.Raycast(MermiCikisNoktasi.transform.position, MermiCikisNoktasi.transform.forward, out hit, Menzil))
        {
            MuzzleFlash.Play();
            SesKaynak.Play();
            SesKaynak.clip = AtesSesi;
            Debug.Log(hit.transform.name);

            if(hit.transform.tag == "Enemy")
            {
                EnemyHealth enemyHealthScript = hit.transform.GetComponent<EnemyHealth>();
                enemyHealthScript.DeductHealth(damageenemy);
            }
            else
            {
                Debug.Log("Iskaladin");
            }
        }
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1.5f);
        mermi = mermi + eklenenmermi;
        tasinanmermi = tasinanmermi - eklenenmermi;
    }
}