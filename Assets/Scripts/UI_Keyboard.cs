namespace VRTK.Examples
{
    using System.IO;
    using UnityEngine;
    using UnityEngine.UI;

    public class UI_Keyboard : MonoBehaviour
    {
        public InputField input;
        public string outfile;
        public GameObject writer;
        public void ClickKey(string character)
        {
            input.text += character;
        }

        public void Backspace()
        {
            if (input.text.Length > 0)
            {
                input.text = input.text.Substring(0, input.text.Length - 1);
            }
        }

        public void Enter()
        {
            VRTK_Logger.Info("You've typed [" + input.text + "]");
            //send the input text to the writer to put it on a file
            outfile = input.text;
            input.text = "";
            //Enable the writer to write **IF ALWAYS ON THERE WILL BE FREQUENT UPDATES**
            writer.SetActive(true);
            //Turn Keyboard off until next scene
            this.gameObject.SetActive(false);
           
        }

        private void Start()
        {
            input = GetComponentInChildren<InputField>();
        }

    }
}