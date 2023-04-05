using UnityEngine;

public class DebugWindow : MonoBehaviour //The MonoBehaviour class is the base class from which every Unity script derives that provides access to a large collection of event messages
{
    TextMesh textMesh = new TextMesh(); //The Text Mesh component/class generates 3D geometry that displays text strings --> 3D text

    // Use this for initialization
    // Start is called before the first frame update
    void Start()
    {
        textMesh = gameObject.GetComponentInChildren<TextMesh>(); // Search for active reference to a component of textmesh 
    }

    // Implement OnDisable and OnEnable script functions.
    // These functions will be called when the attached GameObject
    // is toggled.
    void OnEnable()
    {
        Application.logMessageReceived += LogMessage; //receive log message from only main stream
    }

    // This function is called when the behaviour becomes disabled and can be used for any cleanup code after compilation
    void OnDisable()
    {
        Application.logMessageReceived -= LogMessage; //clean up
    }

    public void LogMessage(string message, string stackTrace, LogType type)
    {
        if(textMesh ==null)
        {
            textMesh = gameObject.GetComponentInChildren<TextMesh>();
        }

        if (textMesh.text.Length > 1000)
        {
            textMesh.text = message + "\n";
        }
        else
        {
            textMesh.text = message + "\n";
            //textMesh.text = textMesh.text + " \n " + message + " \n ";
        }
    }
}