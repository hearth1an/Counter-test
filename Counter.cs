using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter1 : MonoBehaviour
{
    [SerializeField] private Text _counterText;

    private float _minNumber = 0;
    private float _count = 0.5f;
    private bool _isCounting = false;

    private Coroutine _counterCoroutine;
    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_count);
    }

    private void Update()
    {
        int button = 0;

        if (Input.GetMouseButtonDown(button))
        {
            if (_isCounting)
            {
                StopCoroutine(_counterCoroutine);
                _isCounting = false;
            }
            else
            {
                _counterCoroutine = StartCoroutine(CounterRoutine());
                _isCounting = true;
            }
        }
    }

    private IEnumerator CounterRoutine()
    {
        while (true)
        {
            yield return _waitForSeconds;

            _minNumber++;
            _counterText.text = "Ñ÷¸ò÷èê: " + _minNumber;
        }
    }
}