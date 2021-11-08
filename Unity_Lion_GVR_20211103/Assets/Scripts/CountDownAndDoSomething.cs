using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// 倒數計時
/// 並且執行[某件事情]
/// 例如 : 離開遊戲、重新遊戲、顯示選單..
/// </summary>
public class CountDownAndDoSomething : MonoBehaviour
{
    #region 欄位與屬性
    [Header("倒數時間"), Range(1, 5)]
    public float timeCountDown = 3;
    [Header("倒數後事件")]
    public UnityEvent onTimeUp;
    [Header("介面")]
    public Image imgBar;

    private float timeMax;
    /// <summary>
    /// 計時器
    /// </summary>
    private float timer;
    /// <summary>
    /// 開始倒數 : true 開始 、 false 停止
    /// Unity Event 可以存取
    /// 1. 實體物件存取元件內的API
    /// 2. 存取公開方法僅限 : 無或者一個參數、有資料類型限制 ( 基本類型 )
    /// 3. 存取公開屬性 : 有資料類型限制 ( 基本類型 )
    /// </summary>
    public bool startCountDown { get; set; }
    #endregion

    #region 倒數功能
    // 喚醒事件 : 在 Start 前執行一次
    private void Awake()
    {
        timeMax = timeCountDown;
    }

    private void Update()
    {
        CountDown();
    }

    /// <summary>
    /// 倒數計時功能
    /// </summary>
    private void CountDown()
    {
        if (startCountDown)                        //如果 開始 倒數
        {
            if (timer < timeCountDown)             //如果 計時器 小於 倒數時間
            {
                timer += Time.deltaTime;           //累加時間 (於 Update 內呼叫)
            }
            else
            {
                onTimeUp.Invoke();                 //否則 計時器 大於等於 倒數時間 就 呼叫事件
            }

            imgBar.fillAmount = timer / timeMax;   //長度 = 當前時間 / 最大時間
        }
        else
        {
            timer = 0;                             //計時器歸零
            imgBar.fillAmount = 0;                 //長度歸零
        }
    }
    #endregion
}
