using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;

namespace BharatGPT
{
    public partial class MainWindow : Window
    {
        private VoiceOutput voiceOutput;
        private string lastAIResponse = "";

        public MainWindow()
        {
            InitializeComponent();
            voiceOutput = new VoiceOutput();
        }

        private void MicButton_Click(object sender, RoutedEventArgs e)
        {
            ChatBox.AppendText("\n🎙 Listening with Whisper...\n");

            string scriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "listen.py");

            var psi = new ProcessStartInfo
            {
                FileName = @"C:\Users\amudg\AppData\Local\Programs\Python\Python310\python.exe",
                Arguments = $"\"{scriptPath}\"",
                WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            try
            {
                var process = Process.Start(psi);
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                // Wait 2 seconds for file write to complete
                Thread.Sleep(2000);

                string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "recognized.txt");

                if (File.Exists(outputPath))
                {
                    string userText = File.ReadAllText(outputPath).Trim();
                    ChatBox.AppendText("\n🧑 You: " + userText + "\n");

                    string aiReply = GetAIReply(userText);
                    ChatBox.AppendText("🤖 BharatGPT: " + aiReply + "\n");

                    lastAIResponse = aiReply;
                    voiceOutput.Speak(aiReply);

                    File.Delete(outputPath); // optional
                }
                else
                {
                    ChatBox.AppendText("\n⚠️ Error: recognized.txt not found.\n");
                    ChatBox.AppendText("\n🔍 Python output: " + output);
                    if (!string.IsNullOrEmpty(error))
                        ChatBox.AppendText("\n❌ Python error: " + error);
                }
            }
            catch (Exception ex)
            {
                ChatBox.AppendText("\n⚠️ Error running Whisper: " + ex.Message + "\n");
            }
        }

        private void SpeakButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(lastAIResponse))
            {
                voiceOutput.Speak(lastAIResponse);
            }
        }

        private string GetAIReply(string input)
        {
            string msg = input.ToLower().Trim();

            if (msg.Contains("hello") || msg.Contains("hi") || msg.Contains("namaste"))
                return "Namaste! Main BharatGPT hoon. Aapka Hinglish AI Assistant.";

            else if (msg.Contains("your name") || msg.Contains("who are you") || msg.Contains("kaun ho"))
                return "Main BharatGPT hoon – Hinglish AI Assistant banaya gaya India ke liye.";

            else if (msg.Contains("how are you"))
                return "Main bilkul theek hoon! Aap kaise ho?";

            else if (msg.Contains("thank"))
                return "Aapka swagat hai!";

            else if (msg.Contains("bye") || msg.Contains("exit"))
                return "Phir milenge! BharatGPT signing off.";

            else if (msg.Contains("motivate") || msg.Contains("motivation"))
                return "Kamyabi unhi ko milti hai jo kabhi haar nahi maante. Aap bhi unhi mein se ek ho! 💪";

            else if (msg.Contains("sad") || msg.Contains("udaas"))
                return "Kabhi kabhi zindagi thodi mushkil hoti hai. Par yaad rakhna, tu akela nahi hai – BharatGPT hamesha yahin hai!";

            else if (msg.Contains("joke") || msg.Contains("funny"))
                return "Student: Sir, neend aa rahi hai...\nSir: Sapne mein attendance le lunga! 😂";

            else if (msg.Contains("poem") || msg.Contains("kavita"))
                return "Chandni raat, thandi hawa,\nSapno mein kho jao zara...\nMain BharatGPT, aapka dost sada!";

            else if (msg.Contains("story") || msg.Contains("kahani"))
                return "Ek baar ki baat hai, ek student tha jo AI banana chahta tha. Usne BharatGPT banaya — aur duniya dekhte reh gayi! 🚀";

            else if (msg.Contains("excuse") || msg.Contains("college"))
                return "Sir/Madam, aaj mai health issue ke kaaran class attend nahi kar paya. Kal se regular rahunga. 🙏";

            else if (msg.Contains("study") || msg.Contains("padhna"))
                return "Best study tip: Pomodoro method try karo – 25 min padhai + 5 min break. Focus level top ho jaata hai!";

            else if (msg.Contains("love") || msg.Contains("crush"))
                return "Pyaar dosti hai... agar wo samajh jaaye to sahi, warna BharatGPT to hai hi! ❤️";

            else if (msg.Contains("remind") || msg.Contains("reminder"))
                return "Reminder feature set ho gaya bhai! (Advanced version coming soon!)";

            else if (msg.Contains("weather") || msg.Contains("mausam"))
                return "Abhi toh offline hoon... lekin mausam ka mood toh aapke chehre se hi lagta hai! 😄";

            else if (msg.Contains("fact") || msg.Contains("interesting"))
                return "Kya aap jaante hain? Bharat mein duniya ka sabse bada postal network hai – 1.5 lakh se zyada post offices! 📮";

            else if (msg.Contains("Donkey") || msg.Contains("fun"))
                return "Han hu thoda sa! 📮";


            else
                return "Mujhe samajh nahi aaya... thoda aur clearly batayein ya repeat karein 🙏";
        }
    }
}
