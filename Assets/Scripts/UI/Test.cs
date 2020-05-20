/************************************************************
	文件: Test.cs
	作者: 那位先生
	邮箱: 1279544114@qq.com
	日期: 2020/5/20 10:44:21
	功能: UI模板
		  UIFormBase为UI基类
		  FindUIComponent()， RegistEvent()为基类俩个方法
		  在基类初始化时调用
*************************************************************/
using UnityEngine;
using UnityEngine.UI;

public class Test : UIFormBase 
{
	#region UI组件
	private GameObject m_Button;
	private GameObject m_Button_1;
	private GameObject m_Button_2;
	private Text m_Text;
	#endregion

	#region 重新方法
	protected override void FindUIComponent()
	{
		m_Button = transform.Find("Button").gameObject;
		m_Button_1 = transform.Find("Button_1").gameObject;
		m_Button_2 = transform.Find("Button_2").gameObject;
		m_Text = transform.Find("Text").GetComponent<Text>();
	}
	protected override void RegistEvent()
	{
		UIEventListener.RegistListener(UIEventType.Click,m_Button,OnClickButton);
		UIEventListener.RegistListener(UIEventType.Click,m_Button_1,OnClickButton_1);
		UIEventListener.RegistListener(UIEventType.Click,m_Button_2,OnClickButton_2);
	}
	#endregion

	#region UI事件
	private  void OnClickButton(GameObject go)
	{
	}
	private  void OnClickButton_1(GameObject go)
	{
	}
	private  void OnClickButton_2(GameObject go)
	{
	}
	#endregion
}
