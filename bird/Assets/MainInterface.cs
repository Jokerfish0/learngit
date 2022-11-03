using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainInterface : MonoBehaviour
{//������
    public static MainInterface mainInterface;
    Button rectionButton;
    Button confirmButton;
    public static Hashtable hashtable = new Hashtable();
    private void Awake()
    {
        mainInterface = this;

        rectionButton = transform.Find("ע��").GetComponent<Button>();
        confirmButton = transform.Find("��¼").GetComponent<Button>();

        rectionButton.onClick.AddListener(OnRection);
        confirmButton.onClick.AddListener(OnConfirm);
    }
    


    private void OnRection()//ע�����
    {
        NumberRection.numberRection.Show();
        gameObject.SetActive(false);
    }
    private void OnConfirm()//��¼���
    {
        NumberConfirm.numberConfirm.Show();
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
