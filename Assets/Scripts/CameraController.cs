using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 pos; // ��������� ���� Vector3, ���� ����� ���������� ���������� ��������

    private void Awake()
    {
        // ������ ��������, ������ �� ����� ��� ���
        if(!player)
            player = FindObjectOfType<PlayerController>().transform;
    }

    private void Update()
    {
        pos = player.position; // �������� ���������� ������
        pos.z = -10f; // ��������� ������ ���� � ��� �� �������� ��� �����
        pos.y += 3f; // ���������� ������ ���� ��� �� ������� ������ ����

        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime); // � ���������� ���� ������ �
                                                                                    // ������� ������ Lerp(���� �����
                                                                                    // ������ �������� �������)
    }
}
