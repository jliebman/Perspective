using UnityEngine;
using UnityEditor;
using System.IO;
using Valve.VR;
using System.Linq;
using UnityEngine.UI;
using System.Collections;

public class HandleTextFile : MonoBehaviour
{
    [Tooltip("Insert Output File Name")]
    public string outputFile;
    [Tooltip("Attach Spawn Circles")]
    public Circle c1;
    public Circle c2;
    public Circle c3;
    public bool h = false;  //Height
    public bool d = false;  //Depth
    public bool w = false;  //Width
    [Tooltip("Attach element with UI_Keyboard Script")]
    public VRTK.Examples.UI_Keyboard keyboard;
    bool keyboardActive; //Is the Keyboard enabled
    public int count;


    //Writes a string to a file
    private void WriteString(string output, float circle, float circle2, float circle3, string infile)
    {

        string path = "Assets/Resources/" + output + ".txt";
        int[] data = infile.Split(' ').Select(p => int.Parse(p)).ToArray();  //Allows for numbers to be treated individually from the input string
        StreamWriter writer = new StreamWriter(path, true);
        if (data.Length > 3)  //As there are 3 cubes, there must be 3 distances input
        {
            writer.WriteLine("Not enough Info Submitted");
            writer.Close();
        }
        else
        {
            //Write some text to the ouput.txt file  Formatted based on what was being guessed
            if (d)
            {
                writer.WriteLine("Distance 1: " + Mathf.Ceil(circle * 3.280839895f) + " Guessed Distance: " + data[0]);
                writer.WriteLine("Distance 2: " + Mathf.Ceil(circle2 * 3.280839895f) + " Guessed Distance: " + data[1]);
                writer.WriteLine("Distance 3: " + Mathf.Ceil(circle3 * 3.280839895f) + " Guessed Distance: " + data[2]);
            }
            else if (w)
            {
                writer.WriteLine("Width 1: " + Mathf.Ceil(circle * 3.280839895f) + " Guessed Width: " + data[0]);
                writer.WriteLine("Width 2: " + Mathf.Ceil(circle2 * 3.280839895f) + " Guessed Width: " + data[1]);
                writer.WriteLine("Width 3: " + Mathf.Ceil(circle3 * 3.280839895f) + " Guessed Width: " + data[2]);
            }
            else if (h)
            {
                writer.WriteLine("Height 1: " + Mathf.Ceil(circle * 3.280839895f) + " Guessed Height: " + data[0]);
                writer.WriteLine("Height 2: " + Mathf.Ceil(circle2 * 3.280839895f) + " Guessed Height: " + data[1]);
                writer.WriteLine("Height 3: " + Mathf.Ceil(circle3 * 3.280839895f) + " Guessed Height: " + data[2]);
            }
            writer.WriteLine("");
            //writer.WriteLine(infile);
            writer.Close();
        }
    }


    private void Awake()
    {
        outputFile += System.DateTime.UtcNow.ToString("yyyyddmmhh");
        Debug.Log(outputFile);
        //Write to the file based on what info is being written
        if (d)
        {
            WriteString(outputFile, c1.radius, c2.radius, c3.radius, keyboard.outfile);
        }
        else if (h)
        {
            WriteString(outputFile, c1.height, c2.height, c3.height, keyboard.outfile);
        }
        else if (w)
        {
            WriteString(outputFile, c1.width, c2.width, c3.width, keyboard.outfile);
        }

        //Restarts the simulation with a new task in mind 
        if (UnityEngine.SceneManagement.SceneManager.GetSceneAt(1).name == "Depth")
        {
            Debug.Log(UnityEngine.SceneManagement.SceneManager.sceneCount);
            count++;
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(getEnvironment(count));
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(2, UnityEngine.SceneManagement.LoadSceneMode.Additive);
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(1);
        }
        else if (UnityEngine.SceneManagement.SceneManager.GetSceneAt(1).name == "Height")
        {
            Debug.Log("HERE2");
            count++;
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(getEnvironment(count));
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(3, UnityEngine.SceneManagement.LoadSceneMode.Additive);
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(2);
        }
        else if (UnityEngine.SceneManagement.SceneManager.GetSceneAt(1).name == "Width")
        {
            Debug.Log("HERE3");
            count++;
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(getEnvironment(count));
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(1, UnityEngine.SceneManagement.LoadSceneMode.Additive);
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(3);
            
        }
        this.gameObject.SetActive(false);
    }

 
    int getEnvironment(int i)
    {
        if (i % 2 == 0)
        {
            return 4;
        }
        else
            return 0;
    }   
}