using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Scripts.Game.View;

#if UNITY_EDITOR
using UnityEditor.Search;
#endif

public class RightAnswearShower : MonoBehaviour
{
    [SerializeField] private Color _rightAnswearColor;
    [SerializeField] private Color _failureAnswearColor;

    [SerializeField] private TMP_InputField _answearOutputField;

    private Color _defaultColor = new Color(200, 200, 200, 128);


    public void PrintAnswearAsRight(string rightAnswear)
    {
        #if UNITY_EDITOR
            Dispatcher.Enqueue(() => 
            {
                ColorBlock colorBlock = _answearOutputField.colors;
                colorBlock.disabledColor = _rightAnswearColor;
                _answearOutputField.colors = colorBlock;
                _answearOutputField.text = rightAnswear;
            });
        #else
            MultiThreadQueue.AddInMultithreadQueue(() => 
            {
                ColorBlock colorBlock = _answearOutputField.colors;
                colorBlock.disabledColor = _rightAnswearColor;
                _answearOutputField.colors = colorBlock;
                _answearOutputField.text = rightAnswear;
            });
            
        #endif
        
    }
    public void PrintAnswearAsFailure(string rightAnswear)
    {
        #if UNITY_EDITOR
            Dispatcher.Enqueue(() => 
            {
                ColorBlock colorBlock = _answearOutputField.colors;
                colorBlock.disabledColor = _failureAnswearColor;
                _answearOutputField.colors = colorBlock;
                _answearOutputField.text = rightAnswear;
            });
        #else
            MultiThreadQueue.AddInMultithreadQueue(() => 
            {
                ColorBlock colorBlock = _answearOutputField.colors;
                colorBlock.disabledColor = _failureAnswearColor;
                _answearOutputField.colors = colorBlock;
                _answearOutputField.text = rightAnswear;
            });
        #endif
        
    }

    public void ClearRightAnswearField()
    {
        #if UNITY_EDITOR
            Dispatcher.Enqueue(() => 
            {
                ColorBlock colorBlock = _answearOutputField.colors;
                colorBlock.disabledColor = _defaultColor;
                _answearOutputField.colors = colorBlock;
                _answearOutputField.text = "";
            });
        #else
            MultiThreadQueue.AddInMultithreadQueue(() => 
            {
                ColorBlock colorBlock = _answearOutputField.colors;
                colorBlock.disabledColor = _defaultColor;
                _answearOutputField.colors = colorBlock;
                _answearOutputField.text = "";
            });
        #endif
    }
}
