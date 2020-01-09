using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Animations : MonoBehaviour
{
    public IChangeState[] Factors { get; private set; }
    public string[] ParamsNames { get; private set; }

    private Animator _animator;


    private void Start()
    {
        _animator = GetComponent<Animator>();
        Factors = GetComponents<IChangeState>();
        ParamsNames = new string[Factors.Length];

        for(int i = 0; i < Factors.Length; i++)
        {
            ParamsNames[i] = Factors[i].GetParameterName();
        }
    }
    private void Update()
    {
        for(int i = 0; i < Factors.Length; i++)
        {
            _animator.SetFloat
                (ParamsNames[i],
                Factors[i].GetState());
        }
    }
}
