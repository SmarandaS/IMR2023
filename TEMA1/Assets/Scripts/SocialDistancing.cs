using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialDistancing : MonoBehaviour
{
    
    public GameObject other_cactus;

    private float distance = 0f;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    bool AnimatorIsPlaying()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Attack") && stateInfo.normalizedTime < 1.0f)
        {
            return true;
        }
        return false;
    }

    void Update()
    {
        

        if (AnimatorIsPlaying())
        {
            return;
        }

        distance = Vector3.Distance(other_cactus.transform.position, transform.position);
        if(distance < 0.3)
        {
            if (animator != null)
            {
                animator.Play("Base Layer.Attack", 0, 0f);
                Debug.Log("se lasa cu bataie");
            }
        }
        else
        {
            if (animator != null)
            {
                animator.Play("Base Layer.Idle", 0, 0);
                Debug.Log("prea departe");
            }
        }
    }
}
