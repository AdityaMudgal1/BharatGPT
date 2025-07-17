using System.Speech.Synthesis;

namespace BharatGPT
{
    public class VoiceOutput
    {
        private SpeechSynthesizer synthesizer;

        public VoiceOutput()
        {
            synthesizer = new SpeechSynthesizer();

            // Optional: Set voice
            synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
            synthesizer.Rate = 0; // -10 to 10 (speed)
            synthesizer.Volume = 100; // 0 to 100
        }

        public void Speak(string text)
        {
            synthesizer.SpeakAsync(text);
        }
    }
}
