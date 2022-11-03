using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class UIColl : MonoBehaviour
{
    //创建枚举来表示当前游戏状态
   /* public enum Game
    { 
       Start,Playing,Again
    }
    public Game game;*/


    public static UIColl instance;
    private GameObject startGame;
    private GameObject againGame;
    public GameObject Gameing;

    private Button begin;
    private Text grade;
    private Text maxGrade;
    private Text nowGrade;
    private Button again;
    private void Awake()//初始化，将开始界面打开
    {
        instance = this;
        startGame = GameObject.Find("StartGame");
        againGame = GameObject.Find("AgainGame");
        Gameing = GameObject.Find("Gameing");

        begin = transform.Find("StartGame/Begin").GetComponent<Button>();
        grade = transform.Find("Gameing/分数").GetComponent<Text>();
        maxGrade = transform.Find("AgainGame/Panel/最高分显示").GetComponent<Text>();
        nowGrade = transform.Find("AgainGame/Panel/总分显示").GetComponent<Text>();
        again = transform.Find("AgainGame/Panel/Again").GetComponent<Button>();

        startGame.SetActive(true);
        Gameing.SetActive(false);
        againGame.SetActive(false);
    }
    void Start()
    {
        Time.timeScale = 1;
        Bird.instance.birdDied += OnAgain;
        begin.onClick.AddListener(OnBegin);//点击进入游戏状态
        again.onClick.AddListener(AgainGame);//点击重新开始
   
    }

    void OnBegin()
    {
        Bird.instance.BeginGame();
        EnemyMake.instance.StartRun();
        startGame.SetActive(false);
        Gameing.SetActive(true);
    }
    public void OnAgain() //当游戏角色死亡时调用此方法
    {
        Gameing.SetActive(false);
        againGame.SetActive(true);
        OverGrade();
        Time.timeScale = 0;
    }

    //增加分数方法
    public void UpdateGrade(int grade)
    {
        this.grade.text = grade.ToString();
    }
    
    //显示最高分和本局分数,并更新最高分
    private void OverGrade()
    {
        nowGrade.text = grade.text;

        int graded = PlayerPrefs.GetInt("MaxGrade",0);
        int inowGrade = Convert.ToInt32(grade.text);
        int newMaxGrade = graded> inowGrade ? graded : inowGrade;

        PlayerPrefs.SetInt("MaxGrade", newMaxGrade);

        maxGrade.text = newMaxGrade.ToString();
    }

    //重新开始
    private void AgainGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
