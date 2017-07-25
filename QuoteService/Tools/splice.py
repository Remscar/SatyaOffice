from pydub import AudioSegment
from pydub.silence import split_on_silence


# Note: ffmpeg is a dependency
# Link: https://www.reddit.com/r/Windows10/comments/5006is/want_to_install_ffmpeg_under_bash_for_windows/

print "Initializing Splice..."
sound_file = AudioSegment.from_wav("satya2.wav")
audio_chunks = split_on_silence(sound_file, 
    # must be silent for at least a second
    min_silence_len=1000,

    # consider it silent if quieter than -55 dBFS (for large satya speech)
    silence_thresh= -55,
    keep_silence = 500
)
print "before for loop"
print audio_chunks
for i, chunk in enumerate(audio_chunks):
	out_file = "../Audio/chunk{0}.wav".format(i)
	print "exporting", out_file
	chunk.export(out_file, format="wav")