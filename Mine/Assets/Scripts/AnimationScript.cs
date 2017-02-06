using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour {
    Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            {
                animator.SetBool("Mining", true);

            }
        }
	}
}
