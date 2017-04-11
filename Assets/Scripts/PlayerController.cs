using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    [SerializeField] private int m_shotCount;
    [SerializeField] private int m_BulletBoxCount;
    [SerializeField] private Text BulletText;
    [SerializeField] private Text BulletBoxText;
    [SerializeField] private GunController gunController;
    [SerializeField] private TargetController targetController;
    private AudioSource m_AudioSource;
    private bool m_gunfire;

	// Use this for initialization
    void Start () {
        m_shotCount = 30;
        m_BulletBoxCount = 150;
        BulletText.text = "Bullet: " + m_shotCount + "/30";
        BulletBoxText.text = "BulletBox: " + m_BulletBoxCount;
        m_gunfire = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown ("Fire1") && m_gunfire == true) {
            if (m_shotCount > 0) {
                gunController.Fire ();
                gunController.PlayShootingSound ();
                m_shotCount -= 1;
                BulletText.text = "Bullet: " + m_shotCount + "/30";
                m_gunfire = false;
                Invoke ("coolTime", 0.5f);
            }             
        }
        if(Input.GetKeyDown(KeyCode.R) && m_shotCount < 30){
            reloadTime ();
            gunController.PlayReloadSound ();
        }
	}

    private void changeText_GunNum(int num){
        BulletText.text = "BulletBox: " + m_shotCount;
    }

    private void coolTime(){
        m_gunfire = true;
    }

    private void reloadTime(){
        m_BulletBoxCount = m_BulletBoxCount - (30 - m_shotCount);
        m_shotCount = (30 - m_shotCount) + m_shotCount;
        BulletText.text = "Bullet: " + m_shotCount + "/30";
        BulletBoxText.text = "BulletBox: " + m_BulletBoxCount;
    }
}
