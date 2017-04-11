using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {
    private Animator anim;
    private int targetHP;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator> ();
        targetHP = 5;
	}
	
	// Update is called once per frame
    void Damage(){
        targetHP -= 1;
        if (targetHP <= 0) {
            CollapseTarget ();
            Invoke ("StandTarget", 10f);
        }
            
    }

    void CollapseTarget(){
            anim.SetBool ("IsCollapse", true);
    }

    void StandTarget(){
            anim.SetBool ("IsCollapse", false);
            targetHP = 5;
    }
}