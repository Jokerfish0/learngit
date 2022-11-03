using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warning : MonoBehaviour
{//��ʾ����
    public static Warning warning; 
    private Button okButton;
    private Text info;
    private void Awake()
    {
        warning = this;
        okButton = transform.Find("ȷ�ϰ�ť").GetComponent<Button>();
        info = transform.Find("Info").GetComponent<Text>(); 
        okButton.onClick.AddListener(OnOkButton);
        gameObject.SetActive(false);
    }

    private void OnOkButton()
    {
        gameObject.SetActive(false);
    }
    public void ShowInfo(string Info)
    {
        gameObject.SetActive(true);
        info.text = Info;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    
}
