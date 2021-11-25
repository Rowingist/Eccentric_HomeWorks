using UnityEngine;
using TMPro;
using System.Collections;

[RequireComponent(typeof(TMP_Text))]
public class TextDelay : MonoBehaviour
{
    [TextArea (5, 20), SerializeField] private string _inputString;
    [SerializeField] private float _typpingDelay = 0.1f;

    private TMP_Text _endGameText;

    private void Awake()
    {
        _endGameText = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        StartCoroutine(TypeText(_typpingDelay));
    }

    private IEnumerator TypeText(float delay)
    {
        _endGameText.text = "";
        for (int i = 0; i < _inputString.Length; i++)
        {
            char c = _inputString[i];
            _endGameText.text += c;

            yield return new WaitForSeconds(delay);
        }
    }
}