using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberRection : MonoBehaviour
{//注册界面
    public static NumberRection numberRection;
    Button returnButton;
    Button submitButton;
    InputField accountNumber;
    InputField password01;
    InputField password02;
    Toggle isMan;

    private void Awake()
    {
        numberRection = this;

       

    }
    private void Start()
    {
        isMan = transform.Find("性别/男").GetComponent<Toggle>();
        returnButton = transform.Find("返回").GetComponent<Button>();
        submitButton = transform.Find("提交确认").GetComponent<Button>();
        accountNumber = transform.Find("账号").GetComponent<InputField>();
        password01 = transform.Find("密码").GetComponent<InputField>();
        password02 = transform.Find("密码确认").GetComponent<InputField>();

        returnButton.onClick.AddListener(OnReturn);
        submitButton.onClick.AddListener(OnSubmit);
        gameObject.SetActive(false);
    }

    void OnSubmit()
    {
        if(string.IsNullOrEmpty(accountNumber.text)|| string.IsNullOrEmpty(password01.text) || string.IsNullOrEmpty(password02.text))
        {
            Warning.warning.ShowInfo("请输入账号或密码!");
        }
        else if (password01.text != password02.text)
        {
            Warning.warning.ShowInfo("密码不一致！");
        }
        else
        {

            if (GameManager.Instance.GetUserInfo(accountNumber.text)!=null)
            {
                Warning.warning.ShowInfo("账号已被注册！");
            }
            else {
                UserInfo userInfo = new UserInfo(accountNumber.text, password01.text, isMan.isOn);
                GameManager.Instance.SaveUserInfo(userInfo);
                Warning.warning.ShowInfo("注册成功，请登录！");
            }
            
        }
        accountNumber.text =null;
        password01.text = null;
        password02.text = null;
    }

    void OnReturn()
    {
        MainInterface.mainInterface.Show();
        Warning.warning.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    } 

    //接收账号
}
