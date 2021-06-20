import pickle
import librosa
import numpy as np
import pandas as pd
import sys
import warnings
import librosa.display
import matplotlib.pyplot as plt
import os
warnings.filterwarnings('ignore', category=UserWarning)

FRAME_SIZE = 1024
HOP_LENGTH = 512

def amplitude_envelope(signal, frame_size, hop_length):
    amplitude_envelope = []
    
    for i in range(0, len(signal), hop_length):
        current_frame_amplitude_envelope = max(signal[i:i+frame_size])
        amplitude_envelope.append(current_frame_amplitude_envelope)
        
    return np.array(amplitude_envelope)



def Voice_Data_Generator(file, data):
    voice, sr = librosa.load(file)
        
    data.append([np.average(amplitude_envelope(voice, FRAME_SIZE, HOP_LENGTH)), np.average(librosa.feature.rms(voice, frame_length = FRAME_SIZE, hop_length = HOP_LENGTH)[0])
, np.average(librosa.feature.zero_crossing_rate(voice, frame_length = FRAME_SIZE, hop_length = HOP_LENGTH)[0])
, np.average(np.abs(np.fft.fft(voice))), np.average(librosa.power_to_db(librosa.feature.melspectrogram(voice, sr = sr, n_fft = FRAME_SIZE, hop_length = HOP_LENGTH, n_mels = 10)))
, np.average(librosa.feature.mfcc(voice, n_mfcc = 13, sr = sr)), np.average(librosa.feature.spectral_centroid(y = voice, sr = sr, n_fft = FRAME_SIZE, hop_length = HOP_LENGTH)[0])
])
    ae_voice = amplitude_envelope(voice, FRAME_SIZE, HOP_LENGTH)
    rms_voice = librosa.feature.rms(voice, frame_length = FRAME_SIZE, hop_length = HOP_LENGTH)[0]
    zcr_voice = librosa.feature.zero_crossing_rate(voice, frame_length = FRAME_SIZE, hop_length = HOP_LENGTH)[0]
    ft = np.fft.fft(voice)
    magnitude_spectrum = np.abs(ft)
    mel_spectrogram = librosa.feature.melspectrogram(voice, sr = sr, n_fft = FRAME_SIZE, hop_length = HOP_LENGTH, n_mels = 10)
    log_mel_spectrogram = librosa.power_to_db(mel_spectrogram)
    mfccs = librosa.feature.mfcc(voice, n_mfcc = 13, sr = sr)
    sc_voice = librosa.feature.spectral_centroid(y = voice, sr = sr, n_fft = FRAME_SIZE, hop_length = HOP_LENGTH)[0]
    figure = plt.figure(figsize=(10,10))
    plt.subplot(4,2,1)

    librosa.display.waveplot(voice, alpha=0.5)
    plt.title("Waveform of Voice")
    plt.ylim(-1,1)

    frames = range(len(ae_voice))
    t = librosa.frames_to_time(frames, hop_length = HOP_LENGTH)

    plt.subplot(4,2,2)

    librosa.display.waveplot(voice, alpha=0.5)
    plt.plot(t, ae_voice, color="r")
    plt.title("Amplitude Envelope of Voice")
    plt.ylim(-1,1)

    frames = range(len(rms_voice))
    t = librosa.frames_to_time(frames, hop_length = HOP_LENGTH)

    plt.subplot(4,2,3)
    librosa.display.waveplot(voice, alpha=0.5)
    plt.plot(t, rms_voice, color="r")
    plt.title("Root Mean Square Energy of Voice")
    plt.ylim(-1,1)

    plt.subplot(4,2,4)
    plt.plot(t, zcr_voice, color="r") 
    plt.title("Zero Crossing Rate of Voice")
    plt.ylim(0, 1)


    plt.subplot(4,2,5)
    frequency = np.linspace(0, sr, len(magnitude_spectrum))
    num_frequency_bins = int(len(frequency) * 0.5)

    plt.plot(frequency[:num_frequency_bins], magnitude_spectrum[:num_frequency_bins])
    plt.xlabel("Frequency (Hz)")
    plt.ylabel("Magnitude")
    plt.title("Magnitude Spectrum of Voice")

    plt.subplot(4,2,6)
    librosa.display.specshow(log_mel_spectrogram, x_axis = "time", y_axis = "mel", sr = sr)
    plt.colorbar(format = "/+2.f")
    plt.title("Mel Spectrogram of Voice")

    plt.subplot(4,2,7)
    librosa.display.specshow(mfccs, x_axis = "time", sr = sr)
    plt.colorbar(format = "%+2f")
    plt.title("MFCCs of Voice")


    frames = range(len(sc_voice))
    t = librosa.frames_to_time(frames)

    plt.subplot(4,2,8)
    plt.plot(t, sc_voice, color = 'r')
    plt.title("Spectral Centroid of Voice")

    figure.tight_layout()
    figure.savefig('Features.jpg', bbox_inches='tight', dpi=150)

model = None
if(sys.argv[2] == 'lr'):
    model = pickle.load(open('lrmodel.sav', 'rb'))
elif(sys.argv[2] == 'rf'):
    model = pickle.load(open('rfmodel.sav', 'rb'))
else:
    print('Not valid algorithm specified')
min_max_scaler = pickle.load(open('minMaxRange.sav', 'rb'))

predictThatData = []
Voice_Data_Generator(sys.argv[1], predictThatData)
predictThatData = min_max_scaler.transform(predictThatData)
prediction = model.predict(predictThatData)

if(prediction[0] == 1):
    print('Male')
else:
    print('Female')