using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberConfirm : MonoBehaviour
{//��¼����
    public static NumberConfirm numberConfirm;
    Button returnButton;
    Button submitButton;
    InputField accountNumber;
    InputField password01;

    private void Awake()
    {
        numberConfirm = this;
        returnButton = transform.Find("��¼����").GetComponent<Button>();
        submitButton = transform.Find("�ύȷ��").GetComponent<Button>();
        accountNumber = transform.Find("�˺�").GetComponent<InputField>();
        password01 = transform.Find("����").GetComponent<InputField>();

        returnButton.onClick.AddListener(OnReturn);
        submitButton.onClick.AddListener(OnSubmit);
        gameObject.SetActive(false);
    }
    void OnSubmit()
    {
        if (string.IsNullOrEmpty(accountNumber.text) || string.IsNullOrEmpty(password01.text))
        {
            Warning.warning.ShowInfo("�������˺Ż�����!");
        }
        else
        {
            if(GameManager.Instance.GetUserInfo(accountNumber.text)!=null)
            {
                UserInfo user = GameManager.Instance.GetUserInfo(accountNumber.text);
                if (user.Password == password01.text)
                    Warning.warning.ShowInfo("��¼�ɹ���");
                else
                {
                    Warning.warning.ShowInfo("�������");
                }

            }
            else
            {
                Warning.warning.ShowInfo("�˺Ų����ڣ�");
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
