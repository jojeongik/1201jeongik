using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManger : MonoBehaviour
{


    //public int Health_Point;
    public PlayerMoving player;
    public GameObject[] Stages;
    public GameObject Restart_Button;
    public Text playerLevelText;
    public Text playerHpText;
    public GameObject menuSet;
    static int StageIndex;
    static int isLoad;
    public bool isSlow;
 

    //public Image[] Life;

    void Start()
    {
        if(isLoad == 0)
        {
            isLoad = 2;
        }
        else if (isLoad == 1)
        {
            GameLoad();
            isLoad++;
        }
        else if(isLoad == 2)
        {
            SceneLoad();
        }
    }
    private void Awake()
    {
        playerLevelText.text = "Lv . " + player.PlayerLevel.ToString();
        playerHpText.text = player.CurrentHp.ToString() + " / " + player.PlayerHp.ToString();
        isSlow = false;

    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
            {
                menuSet.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                menuSet.SetActive(true);
                Time.timeScale = 0;
            }                
        }       
    }
    private void FixedUpdate()
    {
        playerLevelText.text = "Lv . " + player.PlayerLevel.ToString();
        playerHpText.text = player.CurrentHp.ToString() + " / " + player.PlayerHp.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerReposition();
            HealthDown(10); //낙뎀 10
        }
    }
    //public void HealthDown()
    //{
    //    if(Health_Point>1)
    //    {
    //        Health_Point--;
    //        Life[Health_Point].color = new Color(1, 0, 0, 0.4f);
    //    }
    //    else
    //    {
    //        Health_Point--;
    //        Life[Health_Point].color = new Color(1, 0, 0, 0.4f);
    //        player.OnDie();
    //        Text buttonText = Restart_Button.GetComponentInChildren<Text>();
    //        Restart_Button.SetActive(true);
    //    }
    //}
    public void HealthDown(float damage)
    {
        if (player.CurrentHp > 0)
        {
            player.CurrentHp -= damage;
            if(player.CurrentHp <= 0) 
            {
                player.OnDie();
                Text buttonText = Restart_Button.GetComponentInChildren<Text>();
                Restart_Button.SetActive(true);
            }
        }
        else
        {
            player.CurrentHp -= damage;
            player.OnDie();
            Text buttonText = Restart_Button.GetComponentInChildren<Text>();
            Restart_Button.SetActive(true);
        }
    }
    public void PlayerReposition()
    {
        player.transform.position=new Vector3(0, 0, 0);
        player.VelocityZero();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Scene0");
    }
    public void MenuSetStart()
    {
        menuSet.SetActive(false);
        Time.timeScale = 1;
    }
    public void GameSave()
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetInt("PlayerLv", player.PlayerLevel);
        PlayerPrefs.SetFloat("PlayerCurrentExp", player.CurrentExp);
        PlayerPrefs.SetFloat("PlayerAtKDMG", player.PlayerAtkDmg);
        PlayerPrefs.SetFloat("PlayerHp", player.PlayerHp);
        PlayerPrefs.SetFloat("PlayerCurrentHp", player.CurrentHp);
        PlayerPrefs.SetInt("SceneIndex", StageIndex);
        PlayerPrefs.Save();
    }
    public void GameLoad()
    {
        //if (!PlayerPrefs.HasKey("PlayerX"))
        //{
        //    return;
        //}
        //if(SceneManager.GetActiveScene().name == "Scene0")
        //{
        //    return;
        //}
        //if (SceneManager.sceneCount < 2)
        //{
        //    return;
        //}
   
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        int PlayerLevel= PlayerPrefs.GetInt("PlayerLv");
        float CurrentExp = PlayerPrefs.GetFloat("PlayerCurrentExp");
        float PlayerAtkDmg = PlayerPrefs.GetFloat("PlayerAtKDMG");
        float PlayerHp = PlayerPrefs.GetFloat("PlayerHp");
        float CurrentHp = PlayerPrefs.GetFloat("PlayerCurrentHp");

        player.transform.position = new Vector3(x, y, 0);
        player.PlayerLevel = PlayerLevel;
        player.CurrentExp = CurrentExp;
        player.PlayerAtkDmg = PlayerAtkDmg;
        player.PlayerHp = PlayerHp;
        player.CurrentHp = CurrentHp;

    }
    public void ExitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        //Application.Quit();
    }
    public void SceneSave()
    {
        PlayerPrefs.SetInt("PlayerLv", player.PlayerLevel);
        PlayerPrefs.SetFloat("PlayerCurrentExp", player.CurrentExp);
        PlayerPrefs.SetFloat("PlayerAtKDMG", player.PlayerAtkDmg);
        PlayerPrefs.SetFloat("PlayerHp", player.PlayerHp);
        PlayerPrefs.SetFloat("PlayerCurrentHp", player.CurrentHp);
        PlayerPrefs.Save();
    }
    public void SceneLoad()
    {
        //if (!PlayerPrefs.HasKey("PlayerCurrentExp"))
        //{
        //    return;
        //}
        //if (SceneManager.GetActiveScene().name == "Scene0")
        //{
        //    return;
        //}
        //if (SceneManager.sceneCount < 2)
        //{
        //    return;
        //}
      
        int PlayerLevel = PlayerPrefs.GetInt("PlayerLv");
        float CurrentExp = PlayerPrefs.GetFloat("PlayerCurrentExp");
        float PlayerAtkDmg = PlayerPrefs.GetFloat("PlayerAtKDMG");
        float PlayerHp = PlayerPrefs.GetFloat("PlayerHp");
        float CurrentHp = PlayerPrefs.GetFloat("PlayerCurrentHp");
        player.PlayerLevel = PlayerLevel;
        player.CurrentExp = CurrentExp;
        player.PlayerAtkDmg = PlayerAtkDmg;
        player.PlayerHp = PlayerHp;
        player.CurrentHp = CurrentHp;
    }
    public void NextStage()
    {
        StageIndex++;
        SceneManager.LoadScene(StageIndex);


        //if (Stage_Index < Stages.Length - 1)
        //{
        //    Stages[Stage_Index].SetActive(false);
        //    Stage_Index++;
        //    Stages[Stage_Index].SetActive(true);
        //    PlayerReposition();

        //    Stage_Text.text = "STAGE " + (Stage_Index + 1);

        //}
        //else
        //{
        //    //game clear
        //    Time.timeScale = 0;
        //    Debug.Log("게임 클리어");
        //    Restart_Button.SetActive(true);
        //    Clear_Text.text = "Game Clear!";
        //}

        //Total_Score += Stage_Score;
        //Stage_Score = 0;
    }
    public void GameStartButton()
    {
        isLoad = 0;
        StageIndex = 1;

        SceneManager.LoadScene(StageIndex);
    }
    public void GameLoadButton()
    {
        isLoad = 1;
        int SceneIndex = PlayerPrefs.GetInt("SceneIndex");
        StageIndex = SceneIndex;

        SceneManager.LoadScene(StageIndex);
    }
    public void ItemSlowSkill()
    {
        isSlow = true;
        Invoke("ItemSlowSkillEnd", 20f);
    }
    public void ItemSlowSkillEnd()
    {
        isSlow = false;
    }

}
