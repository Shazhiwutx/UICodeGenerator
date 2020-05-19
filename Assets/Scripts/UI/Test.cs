/************************************************************
	文件: Test.cs
	作者: 那位先生
	邮箱: 1279544114@qq.com
	日期: 2020/5/19 17:4:23
	功能: 功能说明
*************************************************************/
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    #region UI组件
    private GameObject m_Button;
    private GameObject m_Button_1;
    private GameObject m_Button_2;
    private GameObject m_Button_3;
    private Text m_Text;
    #endregion

    private void Awake()
    {
        FindUIComponent();
        RegistEvent();
    }
    protected void FindUIComponent()
    {
        m_Button = transform.Find("Button").gameObject;
        m_Button_1 = transform.Find("Button_1").gameObject;
        m_Button_2 = transform.Find("Button_2").gameObject;
        m_Button_3 = transform.Find("Button_3").gameObject;
        m_Text = transform.Find("Text").GetComponent<Text>();
    }
    protected void RegistEvent()
    {
        UIEventListener.RegistListener(UIEventType.Click, m_Button, OnClickButton);
        UIEventListener.RegistListener(UIEventType.Click, m_Button_1, OnClickButton_1);
        UIEventListener.RegistListener(UIEventType.Click, m_Button_2, OnClickButton_2);
        UIEventListener.RegistListener(UIEventType.Click, m_Button_3, OnClickButton_3);
    }

    #region UI事件
    private void OnClickButton(GameObject go)
    {
        Debug.Log(1);
    }
    private void OnClickButton_1(GameObject go)
    {
        Debug.Log(2);
    }
    private void OnClickButton_2(GameObject go)
    {
        Debug.Log(3);
    }
    private void OnClickButton_3(GameObject go)
    {
        Debug.Log(4);
    }
    #endregion
}
