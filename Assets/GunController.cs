using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    [SerializeField] private AudioClip m_ShootingSound;
    [SerializeField] private GameObject gun_fire;
    [SerializeField] private Transform m_muzzle;
    private AudioSource m_AudioSource;
    // Use this for initialization
    void Start () {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {

    }

    public void Fire(){
        Ray ray = new Ray (transform.position, transform.forward);
        RaycastHit hit;
        GameObject instantiated_gun_fire = Instantiate(gun_fire, m_muzzle.position, Quaternion.identity) as GameObject;
        Destroy (instantiated_gun_fire, 0.01f);
        if(Physics.Raycast(ray, out hit)){
            GameObject instantiated_firepoint = Instantiate (gun_fire, hit.point, Quaternion.identity);
            Destroy (instantiated_firepoint, 0.3f);
        }
    }

    public void PlayShootingSound(){
        m_AudioSource.clip = m_ShootingSound;
        m_AudioSource.Play ();
    }
}
