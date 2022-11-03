using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberConfirm : MonoBehaviour
{//登录界面
    public static NumberConfirm numberConfirm;
    Button returnButton;
    Button submitButton;
    InputField accountNumber;
    InputField password01;

    private void Awake()
    {
        numberConfirm = this;
        returnButton = transform.Find("登录返回").GetComponent<Button>();
        submitButton = transform.Find("提交确认").GetComponent<Button>();
        accountNumber = transform.Find("账号").GetComponent<InputField>();
        password01 = transform.Find("密码").GetComponent<InputField>();

        returnButton.onClick.AddListener(OnReturn);
        submitButton.onClick.AddListener(OnSubmit);
        gameObject.SetActive(false);
    }
    void OnSubmit()
    {
        if (string.IsNullOrEmpty(accountNumber.text) || string.IsNullOrEmpty(password01.text))
        {
            Warning.warning.ShowInfo("请输入账号或密码!");
        }
        else
        {
            if(GameManager.Instance.GetUserInfo(accountNumber.text)!=null)
            {
                UserInfo user = GameManager.Instance.GetUserInfo(accountNumber.text);
                if (user.Password == password01.text)
                    Warning.warning.ShowInfo("登录成功！");
                else
                {
                    Warning.warning.ShowInfo("密码错误！");
                }

            }
            else
            {
                Warning.warning.ShowInfo("账号不存在！");
            }
        }
        accountNumber.text = null;
        password01.text = null;
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

    

}
