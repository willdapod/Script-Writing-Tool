using System;
using System.Speech.Recognition;

public class SpeechService
{
    private SpeechRecognitionEngine _recognizer;

    public SpeechService()
    {
        _recognizer = new SpeechRecognitionEngine();
        _recognizer.SetInputToDefaultAudioDevice();
        _recognizer.LoadGrammar(new DictationGrammar());
        _recognizer.SpeechRecognized += (s, e) =>
        {
            Console.WriteLine($"Recognized: {e.Result.Text}");
        };
    }

    public void StartListening() => _recognizer.RecognizeAsync(RecognizeMode.Multiple);
    public void StopListening() => _recognizer.RecognizeAsyncStop();
}
