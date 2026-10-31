using UnityEngine;
using System.Collections;

public class FlashEffect : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Скрываем вспышку при старте игры
        if (spriteRenderer != null)
            spriteRenderer.enabled = false;
    }

    // Метод, который мы будем вызывать при выстреле
    public void TriggerFlash()
    {
        if (spriteRenderer != null)
        {
            // Перезапускаем корутину, чтобы вспышки не конфликтовали при быстрой стрельбе
            StopAllCoroutines();
            StartCoroutine(FlashRoutine());
        }
    }

    private IEnumerator FlashRoutine()
    {
        spriteRenderer.enabled = true; // Показываем вспышку

        // Рандомим поворот спрайта, чтобы каждый выстрел выглядел уникально (опционально)
        transform.localRotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));

        // Время, сколько вспышка горит на экране (в секундах)
        yield return new WaitForSeconds(0.05f);

        spriteRenderer.enabled = false; // Скрываем обратно
    }
}
