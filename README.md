# BharatGPT 🎙🇮🇳

**BharatGPT** is a Hinglish AI Voice Assistant desktop application built using **C# WPF** and powered by **OpenAI Whisper** for offline speech recognition. Designed for Indian users, it can understand and reply to conversational queries in a mix of Hindi + English.

---

## ✨ Features

- 🎤 Voice input via microphone (offline)
- 🧠 Hinglish conversational AI replies
- 🔊 Text-to-speech voice output
- 📄 Integrates with `Whisper` to transcribe speech accurately
- 💡 Pre-built responses for common queries like study tips, jokes, excuses, poems, and more

---

## 🛠 Tech Stack
| Feature          | Stack Used                     |
|------------------|--------------------------------|
| Voice Input      | Python + OpenAI Whisper        |
| Voice Output     | C# System.Speech.Synthesis     |
| UI               | WPF (Windows Presentation Foundation) |
| Transcription    | Whisper `base` model           |
| Audio Recording  | `sounddevice` + `scipy.io.wavfile` |
| Interfacing      | `ProcessStartInfo` (C# → Python)

---

## 📦 Requirements

### ✅ Python 3.10 (Only!)
Don't use 3.11 or 3.13 — they break whisper  
Install from: https://www.python.org/downloads/release/python-3100/

### ✅ Python Dependencies
Open CMD and run:

pip install openai-whisper sounddevice scipy

markdown
Copy
Edit

### ✅ FFmpeg Setup
1. Download from: https://www.gyan.dev/ffmpeg/builds/
2. Extract it (example: `D:\ffmpeg-7.1.1-essentials_build`)
3. Copy `bin` path (e.g., `D:\ffmpeg-7.1.1-essentials_build\bin`)
4. Add that to Environment Variables → System → Path
5. Check with:
ffmpeg -version

shell
Copy
Edit

## 📂 Folder Structure
BharatGPT/
├── BharatGPT.sln # Visual Studio solution
├── MainWindow.xaml / .cs # UI and logic
├── VoiceInput.cs / VoiceOutput.cs
├── listen.py # Voice recorder + Whisper transcriber
├── recognized.txt # Output (auto-generated)
├── temp.wav # Recorded audio (auto-generated)
└── README.md # This file

markdown
Copy
Edit

## 🚀 How It Works
1. App mein 🎙 Mic button dabao.
2. `listen.py` 5 seconds tak audio record karta hai.
3. Whisper use karke voice ko text mein convert karta hai.
4. Text `recognized.txt` mein save hota hai.
5. C# usse read karke logic match karta hai aur reply deta hai.
6. Reply screen pe show hota hai + bolkar sunaya jata hai.

## ▶️ How to Run

### Step 1: Clone the project
git clone https://github.com/AdityaMudgal1/BharatGPT.git

r
Copy
Edit

### Step 2: Open in Visual Studio
- Open `BharatGPT.sln`

### Step 3: Test Python manually
Go to `bin\Debug` folder and run:
python listen.py

markdown
Copy
Edit
- Check if `recognized.txt` is created.

### Step 4: Run the WPF app
- Click on mic → Speak → See AI reply!

## 💬 Supported Queries

| You Say                             | BharatGPT Replies                                |
|-------------------------------------|--------------------------------------------------|
| Hello / Hi / Namaste                | Namaste! Main BharatGPT hoon.                    |
| What is your name?                  | Main BharatGPT hoon – AI Assistant India ke liye.|
| How are you?                        | Main bilkul theek hoon! Aap kaise ho?            |
| Tell me a joke                      | Student: Sir, neend aa rahi hai... 😂            |
| Motivate me                         | Kamyabi unhi ko milti hai jo kabhi haar nahi maante. |
| I am sad                            | Tu akela nahi hai – BharatGPT yahin hai!         |
| Tell a poem                         | Chandni raat, thandi hawa...                     |
| Give a college excuse               | Sir/Madam, aaj mai health issue ke kaaran...     |
| Study tips                          | Pomodoro method try karo – 25 min padhai + 5 min break. |
| Weather                             | Mausam ka mood toh aapke chehre se hi lagta hai! |
| Interesting fact                    | Bharat mein 1.5 lakh se zyada post offices hain! |

👉 Aur bhi logic aap `MainWindow.xaml.cs` ke `GetAIReply()` function mein add kar sakte ho.

## 📸 Screenshot

*(Add your own screenshot here)*

## 🙏 Special Thanks
- [OpenAI Whisper](https://github.com/openai/whisper)
- [FFmpeg](https://ffmpeg.org/)
- Microsoft WPF & .NET
- Aap sabhi ke liye jo ise use kar rahe hain 🙌

## 🧾 License
This project is licensed under the **MIT License** — free to use, modify and distribute.

---
