using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// �˼ƭp��
/// �åB����[�Y��Ʊ�]
/// �Ҧp : ���}�C���B���s�C���B��ܿ��..
/// </summary>
public class CountDownAndDoSomething : MonoBehaviour
{
    #region ���P�ݩ�
    [Header("�˼Ʈɶ�"), Range(1, 5)]
    public float timeCountDown = 3;
    [Header("�˼ƫ�ƥ�")]
    public UnityEvent onTimeUp;
    [Header("����")]
    public Image imgBar;

    private float timeMax;
    /// <summary>
    /// �p�ɾ�
    /// </summary>
    private float timer;
    /// <summary>
    /// �}�l�˼� : true �}�l �B false ����
    /// Unity Event �i�H�s��
    /// 1. ���骫��s�����󤺪�API
    /// 2. �s�����}��k�ȭ� : �L�Ϊ̤@�ӰѼơB������������� ( ������ )
    /// 3. �s�����}�ݩ� : ������������� ( ������ )
    /// </summary>
    public bool startCountDown { get; set; }
    #endregion

    #region �˼ƥ\��
    // ����ƥ� : �b Start �e����@��
    private void Awake()
    {
        timeMax = timeCountDown;
    }

    private void Update()
    {
        CountDown();
    }

    /// <summary>
    /// �˼ƭp�ɥ\��
    /// </summary>
    private void CountDown()
    {
        if (startCountDown)                        //�p�G �}�l �˼�
        {
            if (timer < timeCountDown)             //�p�G �p�ɾ� �p�� �˼Ʈɶ�
            {
                timer += Time.deltaTime;           //�֥[�ɶ� (�� Update ���I�s)
            }
            else
            {
                onTimeUp.Invoke();                 //�_�h �p�ɾ� �j�󵥩� �˼Ʈɶ� �N �I�s�ƥ�
            }

            imgBar.fillAmount = timer / timeMax;   //���� = ��e�ɶ� / �̤j�ɶ�
        }
        else
        {
            timer = 0;                             //�p�ɾ��k�s
            imgBar.fillAmount = 0;                 //�����k�s
        }
    }
    #endregion
}
