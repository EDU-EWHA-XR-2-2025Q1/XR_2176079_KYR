using UnityEngine;
using Vuforia;

public class KYR_Heart_Initializer : MonoBehaviour
{

    public GameObject Target;
    public int cloneCount = 10;

    void Start()
    {
        Instantiate_GameObject();
    }
    void Instantiate_GameObject()
    {
        for (int i = 0; i < GameManager.I.heartsLeft; i++)

        {
            // ������ Ŭ���� ������ position 

            Vector3 randomSphere = Random.insideUnitSphere * 5f;

            randomSphere.y = 0f;

            Vector3 randomPos = randomSphere;



            // ������ Ŭ���� ������ rotation 

            float randomAngle = Random.value * 360f;

            Quaternion randomRot = Quaternion.Euler(0, randomAngle, 0);



            // Ŭ������ ���� 

            GameObject Clone = Instantiate(Target, randomPos, randomRot);



            // Ŭ�� Ȱ��ȭ 

            Clone.SetActive(true);



            // Ŭ���� �̸� ���� 

            Clone.gameObject.name = "Clone-" + string.Format("{0:D4}", i);



            // Ŭ���� �θ� ���� 

            Clone.transform.SetParent(transform);
        }
    }
}