using UnityEngine;
using UnityEngine.Events;         //引用 事件 命名空間

/// <summary>
/// VR 互動物件
/// 1. VR 注視點看到此物件 Enter
/// 2. VR 注視點看到後離開此物件 Exit
/// 3. VR 注視點看到此物件並點選互動按鈕 Click
/// </summary>
public class VRInteractionObject : MonoBehaviour
{
    //Unity 事件用法
    //1. 引用 Events 命名空間
    //2. 定義 Unity Event 類型欄位並設公開
    //3. 想要執行此事件內容的地方呼叫 事件.Invoke();
    //4. 屬性面板設定事件內容
    [Header("事件 : 看到﹑離開與點擊"), Space(10)]
    public UnityEvent onEnter;
    public UnityEvent onExit;
    public UnityEvent onClick;

    /// <summary>
    /// VR 注視點看到此物件 Enter
    /// </summary>
    public void OnPointerEnter()
    {
        onEnter.Invoke();
    }

    /// <summary>
    /// VR 注視點看到後離開此物件 Exit
    /// </summary>
    public void OnPointerExit()
    {
        onExit.Invoke();
    }

    /// <summary>
    /// VR 注視點看到此物件並點選互動按鈕 Click
    /// </summary>
    public void OnPointerClick ()
    {
        onClick.Invoke();
    }
}
