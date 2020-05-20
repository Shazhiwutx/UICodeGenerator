using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFormBase : MonoBehaviour
{
    private void Awake()
    {
        FindUIComponent();
        RegistEvent();
    }
    protected virtual void FindUIComponent() { }
    protected virtual void RegistEvent() { }
}
