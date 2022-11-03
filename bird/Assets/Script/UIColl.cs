using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class UIColl : MonoBehaviour
{
    //����ö������ʾ��ǰ��Ϸ״̬
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
    private void Awake()//��ʼ��������ʼ�����
    {
        instance = this;
        startGame = GameObject.Find("StartGame");
        againGame = GameObject.Find("AgainGame");
        Gameing = GameObject.Find("Gameing");

        begin = transform.Find("StartGame/Begin").GetComponent<Button>();
        grade = transform.Find("Gameing/����").GetComponent<Text>();
        maxGrade = transform.Find("AgainGame/Panel/��߷���ʾ").GetComponent<Text>();
        nowGrade = transform.Find("AgainGame/Panel/�ܷ���ʾ").GetComponent<Text>();
        again = transform.Find("AgainGame/Panel/Again").GetComponent<Button>();

        startGame.SetActive(true);
        Gameing.SetActive(false);
        againGame.SetActive(false);
    }
    void Start()
    {
        Time.timeScale = 1;
        Bird.instance.birdDied += OnAgain;
        begin.onClick.AddListener(OnBegin);//���������Ϸ״̬
        again.onClick.AddListener(AgainGame);//������¿�ʼ
   
    }

    void OnBegin()
    {
        Bird.instance.BeginGame();
        EnemyMake.instance.StartRun();
        startGame.SetActive(false);
        Gameing.SetActive(true);
    }
    public void OnAgain() //����Ϸ��ɫ����ʱ���ô˷���
    {
        Gameing.SetActive(false);
        againGame.SetActive(true);
        OverGrade();
        Time.timeScale = 0;
    }

    //���ӷ�������
    public void UpdateGrade(int grade)
    {
        this.grade.text = grade.ToString();
    }
    
    //��ʾ��߷ֺͱ��ַ���,��������߷�
    private void OverGrade()
    {
        nowGrade.text = grade.text;

        int graded = PlayerPrefs.GetInt("MaxGrade",0);
        int inowGrade = Convert.ToInt32(grade.text);
        int newMaxGrade = graded> inowGrade ? graded : inowGrade;

        PlayerPrefs.SetInt("MaxGrade", newMaxGrade);

        maxGrade.text = newMaxGrade.ToString();
    }

    //���¿�ʼ
    private void AgainGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
