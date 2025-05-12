using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class KYR_UI_Controller : MonoBehaviour
{
    [Header("UI �ؽ�Ʈ")]
    public TMP_Text PickCounts;
    public TMP_Text PutCounts;

    [Header("Scene ��ȯ ��ư")]
    public Button SwitchSceneButton;   // ��Go to the other scene��

    [Header("Scene02 �߻� ��ư")]
    public Button FireButton;          // ImageTarget Found �� SetActive(true) �Ǵ� ��ư

    // ��������������������������������������������������������������������������������������������������������������������������������������������������������
    // �ʱ�ȭ
    // ��������������������������������������������������������������������������������������������������������������������������������������������������������
    void Start()
    {
        // Scene ������ �� ���� ������ �ؽ�Ʈ �ʱ�ȭ
        PickCounts.text = GameManager.I.pickCount.ToString();
        PutCounts.text = GameManager.I.putCount.ToString();

        // �߻� ��ư Ŭ�� ���� ���� ����
        RefreshFireButton();

        // Scene ��ȯ ��ư ����
        if (SwitchSceneButton != null)
            SwitchSceneButton.onClick.AddListener(GoToOtherScene);
    }

    // ��������������������������������������������������������������������������������������������������������������������������������������������������������
    // Pick / Put UI ����
    // ��������������������������������������������������������������������������������������������������������������������������������������������������������
    public void Display_PickCounts(int count)
    {
        GameManager.I.pickCount = count;
        PickCounts.text = count.ToString();
        RefreshFireButton();   // Pick ���� ���� ������ ȣ��
    }

    public void Decrease_PickCounts()
    {
        GameManager.I.pickCount--;
        PickCounts.text = GameManager.I.pickCount.ToString();
        RefreshFireButton();   // Pick �پ��� ��ư ��Ȱ��ȭ ����
    }

    public void Display_PutCounts()
    {
        GameManager.I.putCount++;
        PutCounts.text = GameManager.I.putCount.ToString();
    }

    public int GetPickCounts() => GameManager.I.pickCount;

    // ��������������������������������������������������������������������������������������������������������������������������������������������������������
    // �߻� ��ư Ȱ��/��Ȱ�� (���̱�/������ ImageTarget �̺�Ʈ�� ���)
    // ��������������������������������������������������������������������������������������������������������������������������������������������������������
    public void RefreshFireButton()
    {
        if (FireButton != null)
            FireButton.interactable = (GameManager.I.pickCount > 0);
    }

    // ��������������������������������������������������������������������������������������������������������������������������������������������������������
    // Scene01 �� Scene02 ��ȯ
    // ��������������������������������������������������������������������������������������������������������������������������������������������������������
    public void GoToOtherScene()
    {
        string current = SceneManager.GetActiveScene().name;

        if (current == "Scene01")
            SceneManager.LoadScene("Scene02");
        else if (current == "Scene02")
            SceneManager.LoadScene("Scene01");
        else
            Debug.LogWarning($"Unknown scene '{current}'");
    }
}
