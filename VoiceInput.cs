using System;
using System.Speech.Recognition;

namespace BharatGPT
{
    public class VoiceInput
    {
        private SpeechRecognitionEngine recognizer;

        public event Action<string> OnSpeechRecognized;

        public void StartListening()
        {
            try
            {
                // ✅ Use Indian English recognizer
                recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-IN"));
                recognizer.SetInputToDefaultAudioDevice();

                // ✅ Load full dictation grammar (supports random speech)
                recognizer.LoadGrammar(new DictationGrammar());

                // ✅ Hook speech recognized event
                recognizer.SpeechRecognized += (s, e) =>
                {
                    string result = e.Result.Text;

                    // 👇 Debug print in output window (optional)
                    Console.WriteLine("Recognized: " + result);

                    OnSpeechRecognized?.Invoke(result);
                };

                recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Voice error: " + ex.Message);
            }
        }

        public void StopListening()
        {
            recognizer?.RecognizeAsyncStop();
        }
    }
}
