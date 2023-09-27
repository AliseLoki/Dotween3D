using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    private const string Text1 = " TRAVELLER...";
    private const string Text2 = "ENTER THE PASSWORD";
    private const string Text3 = "QWERTY";

    [SerializeField] private Text _text;

    private float _duration = 5f;
    private float _delay = 6f;
    private float _holdup = 12f;

    private void Start()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(_text.DOText(Text1, _duration).SetRelative());
        sequence.Insert(_delay, _text.DOText(Text2, _duration));
        sequence.Insert(_holdup, _text.DOText(Text3, _duration, true, ScrambleMode.All));
    }
}
