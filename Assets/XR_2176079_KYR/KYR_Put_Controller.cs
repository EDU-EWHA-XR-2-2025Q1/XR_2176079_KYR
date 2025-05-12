using UnityEngine;
using UnityEngine.UI;

public class KYR_Put_Controller : MonoBehaviour
{
    [Header("���� ������(��Ʈ) ������")]
    public GameObject TargetObjectToThrow;
    [Header("�÷��̾� ī�޶�")]
    public Transform PlayerCamera;
    [Header("UI ��Ʈ�ѷ�")]
    public KYR_UI_Controller UI;
    [Header("�߻� ��ư")]
    public Button FireButton;

    void Start()
    {
        // �߻� ��ư Ŭ�� �̺�Ʈ ����
        if (FireButton != null)
            FireButton.onClick.AddListener(OnFireButtonPressed);
    }

    void OnFireButtonPressed()
    {
        // PickCount�� 1 �̻��� ���� �߻�
        if (UI.GetPickCounts() > 0)
        {
            Throw();
            UI.Decrease_PickCounts();
        }
    }

    public void Throw()
    {
        // ī�޶� ���� ��(0.5m)���� ����
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
