using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    [SerializeField] private Camera m_camera;
    [SerializeField] private int m_shotCount;
    [SerializeField] private int m_BulletBoxCount;
    [SerializeField] private Text BulletText;
    [SerializeField] private Text BulletBoxText;
    [SerializeField] private Text ScoreText;
    [SerializeField] private Text TimeText;
    [SerializeField] private GunController gunController;
    [SerializeField] private TargetController targetController;
    [SerializeField] private float m_limitTime;
    [SerializeField] private GameObject Reticle;
    [SerializeField] private GameObject Snipe;
    [SerializeField] private GameObject Scope;
    private AudioSource m_AudioSource;
    private bool m_gunfire;
    private int m_score;
    private int m_point;
    private float m_countTime;
    private bool m_snipemode;
	// Use this for initialization

    private void Start () {
        m_shotCount = 30;
        m_BulletBoxCount = 150;
        m_score = 0;
        BulletText.text = "Bullet: " + m_shotCount + "/30";
        BulletBoxText.text = "BulletBox: " + m_BulletBoxCount;
        ScoreText.text = "Pt: " + m_score;
        m_gunfire = true;
        Snipe.SetActive (false);
        Scope.SetActive (false);
        m_snipemode = false;
    }
	
	// Update is called once per frame
    private void Update () {
        m_countTime += Time.deltaTime;
        TimeText.text = "Time: " + (m_limitTime - m_countTime).ToString ("F2") + "s";
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
            ReloadTime ();
            gunController.PlayReloadSound ();
        }

        if (Input.GetButtonDown ("Fire2") && m_snipemode == false) {
            Reticle.SetActive (false);
            Snipe.SetActive (true);
            Scope.SetActive (true);
            m_snipemode = true;
            m_camera.fieldOfView = 20.0f;
        } else if (Input.GetButtonDown ("Fire2") && m_snipemode == true) {
            Reticle.SetActive (true);
            Snipe.SetActive (false);
            Scope.SetActive (false);
            m_snipemode = false;
            m_camera.fieldOfView = 70.0f;
        }
    }

    private void ChangeText_GunNum(int num){
        BulletText.text = "BulletBox: " + m_shotCount;
    }

    private void CoolTime(){
        m_gunfire = true;
    }

    private void ReloadTime(){
        m_BulletBoxCount = m_BulletBoxCount - (30 - m_shotCount);
        m_shotCount = (30 - m_shotCount) + m_shotCount;
        BulletText.text = "Bullet: " + m_shotCount + "/30";
        BulletBoxText.text = "BulletBox: " + m_BulletBoxCount;
    }

    public void ScorePlus(Vector3 hitposition, Vector3 targetPosition){
        m_point = (int)(2 / ((hitposition - targetPosition).magnitude + 1e-4));
        m_score += m_point;
        ScoreText.text = "Pt :" + m_score;
    }
}
