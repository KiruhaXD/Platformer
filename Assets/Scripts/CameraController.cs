using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 pos; // приватное поле Vector3, куда будем записывать координаты движения

    private void Awake()
    {
        // делаем проверку, найден ли игрок или нет
        if(!player)
            player = FindObjectOfType<PlayerController>().transform;
    }

    private void Update()
    {
        pos = player.position; // получаем координаты игрока
        pos.z = -10f; // фиксируем игрока чтоб у нас не пропадал сам игрок
        pos.y += 3f; // поправляем камеру чтоб она не улетала сильно вниз

        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime); // и перемещаем туда камеру с
                                                                                    // помощью метода Lerp(этот метод
                                                                                    // делает движение плавным)
    }
}
