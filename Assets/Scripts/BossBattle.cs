using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BossBattle : MonoBehaviour
{
    public Text chance1;

    public GameObject bossDie;
    public float StartDifficulty;
    float Difficulty;
    public Animator anim;
    public AudioClip cl;
    public float startCount;
    float Count;
    float startTime;
    public Text t;
    public Image i;
    float Chances;
    // Start is called before the first frame update
    void Start()
    {
        Chances = 4;
        Difficulty = StartDifficulty;
        Count = startCount;
    }
    private void OnEnable()
    {
        startTime = Time.realtimeSinceStartup;
    }
    public void setDifficulty(Sprite bossImage, Vector3 Scale)
    {
        i.sprite = bossImage;
        Difficulty = StartDifficulty;
        Count = startCount-1;
        i.transform.localScale = Scale;
    }
    void Restart()
    {
        Chances--;
        i.GetComponent<Animator>().Play("BossAttack");
        Difficulty = StartDifficulty;
        Count = startCount;
        anim.Play("EnemyDamage");
        GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        chance1.text = "Lives: " + Chances;
        if (Chances < 0)
            SceneManager.LoadScene("DeathScreen");
        Time.timeScale = 0.0001f;
        t.text = "Boss Health: " + (Count+1);
        anim.speed = 1 / Time.timeScale;
        i.GetComponent<Animator>().speed = 1 / Time.timeScale;
        GetComponent<RectTransform>().localScale += new Vector3(Time.deltaTime/Time.timeScale * Difficulty, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (transform.localScale.x > 7.1f && transform.localScale.x < 9.15f)
            {
                Difficulty++;
                i.GetComponent<Animator>().Play("BossDamage");
                anim.Play("DamageEnemy");
                GetComponent<AudioSource>().PlayOneShot(cl);
                GetComponent<AudioSource>().pitch = Difficulty / 2;
                Count -= 1;
            }
            else
            {
                Restart();
            }
            GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
        if (transform.localScale.x > 9.5f)
        {
            Restart();
        }
        if (Count < 0)
        {
            GameObject f = Instantiate(bossDie);
            f.transform.parent = null;
            Destroy(anim.transform.parent.gameObject);
            Time.timeScale = 1;
        }
    }
    }
