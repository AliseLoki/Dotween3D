using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Base : MonoBehaviour
{
    [SerializeField] private int _score;

    [SerializeField] private List<Bot> _bots;
    [SerializeField] private Scanner _scanner;

    public event UnityAction<int> ScoreChanged;

    private void OnEnable()
    {
        _scanner.ResourceWasFound += OnResourceFound;
    }

    private void OnDisable()
    {
        _scanner.ResourceWasFound -= OnResourceFound;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bot bot))
        {
            if (bot.IsTakenResource == true)
            {
                OnScoreChanged();
            }

            bot.PutResource();
        }
    }

    private void OnScoreChanged()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    private void OnResourceFound(Transform target)
    {
        Resource resource = target.GetComponent<Resource>();
        int index = Random.Range(0, _bots.Count);
        var bot = _bots[index];

        if (bot != null)
        {
            if (bot.transform.position != target.position && bot.IsTakenResource == false && bot.IsBusy == false && resource.IsMarked == false)
            {
                resource.SetMarked();
                bot.MoveToTarget(target);
            }
        }
    }
}
