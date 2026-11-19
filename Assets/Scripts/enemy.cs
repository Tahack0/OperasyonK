using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.AI;
public class enemy : MonoBehaviour
{
    public float mesafe;
    public Transform target;
    Vector3 pos;
    Vector3 Offset;//rotation
    private Animator enemyanimator;

    
    
    public ParticleSystem MuzzleFlash;
    RaycastHit hit;
    public GameObject MermiCikisNoktasi;
    public GameObject uzaklik;
    public bool AtesEdebilir;
    float GunTimer;
    public float TaramaHizi;
    public float Menzil;
    public float damagePlayer;
    AudioSource EnemySound;
    

    NavMeshAgent nMesh;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyanimator = GetComponent<Animator>();
        EnemySound = GetComponent<AudioSource>();
        nMesh = GetComponent<NavMeshAgent>();

        
      
    }

    // Update is called once per frame
    void Update()
    {
        mesafe = Vector3.Distance(transform.position, target.position);
        pos = new Vector3(target.position.x, transform.position.y, target.position.z);

        enemyanimator.SetFloat("walk", mesafe);
        if (mesafe < 30f)
        {
            if (mesafe > 15f)
            {
                nMesh.destination = target.position;
            }
        }

        if (mesafe < 15f)
        {
            transform.LookAt(pos);
            Quaternion rotation = Quaternion.LookRotation(target.transform.position - this.transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation , rotation, Time.deltaTime);

            enemyanimator.SetBool("combatmode", true);

            if (Physics.Raycast(MermiCikisNoktasi.transform.position, MermiCikisNoktasi.transform.forward, out hit, Menzil))
            {   
               
                Debug.Log(hit.transform.name);

                if (hit.transform.tag == "Player")
                {    
                    MuzzleFlash.Play();
                    
                    PlayerHealth playerHealthScript = hit.transform.GetComponent<PlayerHealth>();
                    playerHealthScript.HesaplananHealth(damagePlayer);
                }
                else
                {
                    Debug.Log("Iskaladin");
                }
            }
        }
        else
        {
            enemyanimator.SetBool("combatmode", false);
        }
    }
}
