import sys
import io
sys.stdout = io.TextIOWrapper(sys.stdout.buffer, encoding='utf-8')

import whisper
import sounddevice as sd
import numpy as np
import scipy.io.wavfile as wav
import os

try:
    print("Speak now... Recording 5 seconds...")

    duration = 5  # seconds
    sample_rate = 16000

    # Record audio
    recording = sd.rec(int(duration * sample_rate), samplerate=sample_rate, channels=1, dtype='int16')
    sd.wait()

    # Save as WAV
    base_dir = os.path.dirname(os.path.abspath(__file__))
    wav_path = os.path.join(base_dir, "temp.wav")
    wav.write(wav_path, sample_rate, recording)

    # Load model
    model = whisper.load_model("base")

    # Transcribe
    result = model.transcribe(wav_path)

    # Save recognized text
    recognized_path = os.path.join(base_dir, "recognized.txt")
    with open(recognized_path, "w", encoding="utf-8") as f:
        f.write(result["text"])

    print("Recognized:", result["text"])

except Exception as e:
    print("⚠️ Error inside listen.py:", str(e))
