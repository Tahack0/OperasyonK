using UnityEngine;

public class karakteranim : MonoBehaviour
{
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {       //reload anim
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetBool("sarjordegistir", true);
            
        }
        else
        {
            animator.SetBool("sarjordegistir", false);
        }

       
        //ates anim
        if (Input.GetKey(KeyCode.Mouse1))
        {
            animator.SetBool("nefestut", true);
        }
        else
        {
            animator.SetBool("nefestut", false);
        }
        //yürüme anim
        if (Input.GetKey(KeyCode.W ))
        {
            animator.SetBool("walk", true);
        }else if(Input.GetKey(KeyCode.A)) {
            animator.SetBool("walk" , true);
        }else if (Input.GetKey(KeyCode.S))
        {   animator.SetBool("walk", true);
        }else if (Input.GetKey(KeyCode.D))
        { animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }
        //run anim
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }
    }
}
