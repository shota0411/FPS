using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    [SerializeField] private AudioClip m_ShootingSound;
    [SerializeField] private AudioClip m_ReloadSound;
    [SerializeField] private GameObject gun_fire;
    [SerializeField] private GameObject gun_fired;
    [SerializeField] private Transform m_muzzle;
    [SerializeField] private GameObject m_target;
    private AudioSource m_AudioSource;
    // Use this for initialization
    void Start () {
        m_AudioSource = GetComponent<AudioSource>();
    }

    public void Fire(){
        Ray ray = new Ray (transform.position, transform.forward);
        RaycastHit hit;
        GameObject instantiated_gun_fire = Instantiate(gun_fire, m_muzzle.position, Quaternion.identity) as GameObject;
        Destroy (instantiated_gun_fire, 0.1f);
        if(Physics.Raycast(ray, out hit, 20.0f)){
            GameObject instantiated_firepoint = Instantiate (gun_fired, hit.point, Quaternion.identity);
            Destroy (instantiated_firepoint, 0.3f);
            GameObject m_target = hit.collider.gameObject;
        }
    }

    public void PlayShootingSound(){
        m_AudioSource.clip = m_ShootingSound;
        m_AudioSource.Play ();
    }
    public void PlayReloadSound(){
        m_AudioSource.clip = m_ReloadSound;
        m_AudioSource.Play ();
    }
}
