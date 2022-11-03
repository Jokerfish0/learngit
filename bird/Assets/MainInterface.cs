using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainInterface : MonoBehaviour
{//Ö÷½çÃæ
    public static MainInterface mainInterface;
    Button rectionButton;
    Button confirmButton;
    public static Hashtable hashtable = new Hashtable();
    private void Awake()
    {
        mainInterface = this;

        rectionButton = transform.Find("×¢²á").GetComponent<Button>();
        confirmButton = transform.Find("µÇÂ¼").GetComponent<Button>();

        rectionButton.onClick.AddListener(OnRection);
        confirmButton.onClick.AddListener(OnConfirm);
    }
    


    private void OnRection()//×¢²áÃæ°å
    {
        NumberRection.numberRection.Show();
        gameObject.SetActive(false);
    }
    private void OnConfirm()//µÇÂ¼Ãæ°å
    {
        NumberConfirm.numberConfirm.Show();
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
