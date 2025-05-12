using UnityEngine;
using UnityEngine.UI;

public class KYR_Put_Controller : MonoBehaviour
{
    [Header("던질 아이템(하트) 프리팹")]
    public GameObject TargetObjectToThrow;
    [Header("플레이어 카메라")]
    public Transform PlayerCamera;
    [Header("UI 컨트롤러")]
    public KYR_UI_Controller UI;
    [Header("발사 버튼")]
    public Button FireButton;

    void Start()
    {
        // 발사 버튼 클릭 이벤트 연결
        if (FireButton != null)
            FireButton.onClick.AddListener(OnFireButtonPressed);
    }

    void OnFireButtonPressed()
    {
        // PickCount가 1 이상일 때만 발사
        if (UI.GetPickCounts() > 0)
        {
            Throw();
            UI.Decrease_PickCounts();
        }
    }

    public void Throw()
    {
        // 카메라 거의 앞(0.5m)에서 생성
        Vector3 spawnPos = PlayerCamera.position + PlayerCamera.forward * 0.5f;
        Quaternion spawnRot = Random.rotation;

        GameObject clone = Instantiate(TargetObjectToThrow, spawnPos, spawnRot);
        var rb = clone.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddForce(PlayerCamera.forward * 400f);

        Destroy(clone, 3f);
    }
}
