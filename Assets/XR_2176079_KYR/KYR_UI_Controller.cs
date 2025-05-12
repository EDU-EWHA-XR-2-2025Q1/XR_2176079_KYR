using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class KYR_UI_Controller : MonoBehaviour
{
    [Header("UI 텍스트")]
    public TMP_Text PickCounts;
    public TMP_Text PutCounts;

    [Header("Scene 전환 버튼")]
    public Button SwitchSceneButton;   // “Go to the other scene”

    [Header("Scene02 발사 버튼")]
    public Button FireButton;          // ImageTarget Found 시 SetActive(true) 되는 버튼

    // ────────────────────────────────────────────────────────────────────────────
    // 초기화
    // ────────────────────────────────────────────────────────────────────────────
    void Start()
    {
        // Scene 재입장 시 이전 값으로 텍스트 초기화
        PickCounts.text = GameManager.I.pickCount.ToString();
        PutCounts.text = GameManager.I.putCount.ToString();

        // 발사 버튼 클릭 가능 여부 갱신
        RefreshFireButton();

        // Scene 전환 버튼 연결
        if (SwitchSceneButton != null)
            SwitchSceneButton.onClick.AddListener(GoToOtherScene);
    }

    // ────────────────────────────────────────────────────────────────────────────
    // Pick / Put UI 갱신
    // ────────────────────────────────────────────────────────────────────────────
    public void Display_PickCounts(int count)
    {
        GameManager.I.pickCount = count;
        PickCounts.text = count.ToString();
        RefreshFireButton();   // Pick 수가 변할 때마다 호출
    }

    public void Decrease_PickCounts()
    {
        GameManager.I.pickCount--;
        PickCounts.text = GameManager.I.pickCount.ToString();
        RefreshFireButton();   // Pick 줄어들면 버튼 비활성화 가능
    }

    public void Display_PutCounts()
    {
        GameManager.I.putCount++;
        PutCounts.text = GameManager.I.putCount.ToString();
    }

    public int GetPickCounts() => GameManager.I.pickCount;

    // ────────────────────────────────────────────────────────────────────────────
    // 발사 버튼 활성/비활성 (보이기/숨김은 ImageTarget 이벤트가 담당)
    // ────────────────────────────────────────────────────────────────────────────
    public void RefreshFireButton()
    {
        if (FireButton != null)
            FireButton.interactable = (GameManager.I.pickCount > 0);
    }

    // ────────────────────────────────────────────────────────────────────────────
    // Scene01 ↔ Scene02 전환
    // ────────────────────────────────────────────────────────────────────────────
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
