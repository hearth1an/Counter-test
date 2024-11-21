using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Text _counterText;

    private float _minNumber = 0;
    private float _count = 0.5f;
    private bool _isCounting = false;

    private Coroutine _counterCoroutine;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isCounting)
            {
                StopCoroutine(_counterCoroutine);
                _isCounting = false;
            }
            else
            {
                // Запуск корутины
                _counterCoroutine = StartCoroutine(CounterRoutine());
                _isCounting = true;
            }
        }
    }

    private IEnumerator CounterRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_count);
            _minNumber++;

            _counterText.text = "Счётчик: " + _minNumber;
        }
    }
}
