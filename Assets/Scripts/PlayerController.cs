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
    private AudioSource m_AudioSource;
    private int m_bullet = 30;
    private int m_bullet_box = 150;
    private RaycastHit hit;
    private Ray ray;
    private float m_range = 20f;
    private float m_width = 0.01f;
    private Vector3 cameraCenter = new Vector3 (Screen.width / 2, Screen.height / 2, 0);
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
	}

    private void changeText_GunNum(int num){
        BulletText.text = "BulletBox: " + m_shotCount;
    }

    private void coolTime(){
        m_gunfire = true;
    }

}
