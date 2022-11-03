using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberRection : MonoBehaviour
{//ע�����
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
        isMan = transform.Find("�Ա�/��").GetComponent<Toggle>();
        returnButton = transform.Find("����").GetComponent<Button>();
        submitButton = transform.Find("�ύȷ��").GetComponent<Button>();
        accountNumber = transform.Find("�˺�").GetComponent<InputField>();
        password01 = transform.Find("����").GetComponent<InputField>();
        password02 = transform.Find("����ȷ��").GetComponent<InputField>();

        returnButton.onClick.AddListener(OnReturn);
        submitButton.onClick.AddListener(OnSubmit);
        gameObject.SetActive(false);
    }

    void OnSubmit()
    {
        if(string.IsNullOrEmpty(accountNumber.text)|| string.IsNullOrEmpty(password01.text) || string.IsNullOrEmpty(password02.text))
        {
            Warning.warning.ShowInfo("�������˺Ż�����!");
        }
        else if (password01.text != password02.text)
        {
            Warning.warning.ShowInfo("���벻һ�£�");
        }
        else
        {

            if (GameManager.Instance.GetUserInfo(accountNumber.text)!=null)
            {
                Warning.warning.ShowInfo("�˺��ѱ�ע�ᣡ");
            }
            else {
                UserInfo userInfo = new UserInfo(accountNumber.text, password01.text, isMan.isOn);
                GameManager.Instance.SaveUserInfo(userInfo);
                Warning.warning.ShowInfo("ע��ɹ������¼��");
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

    //�����˺�
}
