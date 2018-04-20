using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    private static int score;
    public Transform bullet_spawn_position;
    public GameObject bullet;
    CharacterController cr;
    private float speed = 3.0f;
    private Vector3 prev_angles;
    public Camera cam;
    private float smoothing = 1.0f;
    private float offset_bullet = .89f;
    public Text scoreText;
    public GameObject gameOverPanel;
    private int limitEnemy = 50;
    public GameObject enemy;
    private static PlayerController pl;
    public Transform [] spawn_pos;
    private AudioSource shoot_sound;
    private int prev_index;
    void Awake()
    {
        gameOverPanel.SetActive(false);
        pl = GetComponent<PlayerController>();
    }
    void Start()
    {
        score = 0;
        Time.timeScale = 1;
        cr = GetComponent<CharacterController>();
        shoot_sound = GetComponent<AudioSource>();

        //first spawn one enemy////////////////
        for(int i = 1; i <= 4; i++)
        {
            enemy_spawn();
        }
    }
    void Update()
    {

        transform.position = new Vector3(transform.position.x, 1.7f, transform.position.z);
        #region
        //player movement control
        float x_axis = CrossPlatformInputManager.GetAxis("Horizontal");
        float z_axis = CrossPlatformInputManager.GetAxis("Vertical");
        Vector3 move_details = new Vector3(x_axis * speed * Time.deltaTime, 0, z_axis * speed * Time.deltaTime);
        cr.Move(move_details);
        #endregion

        //angle of the player
        if (x_axis != 0 || z_axis != 0)
        {
            float inputAngle = 90 - (Mathf.Atan2(z_axis, x_axis)) * Mathf.Rad2Deg;

            transform.eulerAngles = Vector3.up * inputAngle;
            prev_angles = transform.eulerAngles;

        }
        else
        {
            transform.eulerAngles = prev_angles;
        }


        //score update////
        scoreText.text = score.ToString();

    }
    public static void IncScore(int amount)
    { ///this function call means an enemy died
        //so we should spawn more enemy

        score += amount;

        //call to enemy spawn
        pl.enemy_spawn();
    }
    public void instantiate_Bullet()
    {
        GameObject bl = Instantiate(bullet, bullet_spawn_position.position, transform.rotation) as GameObject;
        shoot_sound.Play();
    }
    public static int getScore()
    {
        return score;
    }
    public void enemy_spawn()
    {
       
        int index = Random.Range(0, spawn_pos.Length - 1);
        while (prev_index == index)
        {
            index = Random.Range(0, spawn_pos.Length - 1);
        }
        Debug.Log(prev_index + " " + index);
        prev_index = index;
      
        GameObject enm = Instantiate(enemy, spawn_pos[index].position, Quaternion.identity) as GameObject;
    }

}
