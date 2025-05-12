using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    public int pickCount;
    public int putCount;
    public int heartsLeft = 10;   // Scene01�� ���� �ִ� ��Ʈ ��

    void Awake()
    {
        if (I == null) { I = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }
    }

    public static void Load(string scene) => SceneManager.LoadScene(scene);
}
