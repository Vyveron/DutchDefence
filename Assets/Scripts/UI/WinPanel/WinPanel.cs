using TMPro;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    public TextMeshProUGUI textField;
    public UIMover mover;
    public int wave;
    public float informTime = 3f;


    private void Start()
    {
        WaveObserver.onWaveFinished.AddListener(() => { wave++; });
        WaveObserver.onWaveFinished.AddListener(Inform);
    }

    public void Inform()
    {
        mover.Show();
        textField.text = "You've survived " + wave.ToString() + " waves!";
        Invoke("Hide", informTime);
    }
    public void Hide()
    {
        mover.Hide();
    }
}
