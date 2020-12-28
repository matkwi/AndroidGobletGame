using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreSettings {

    private static bool _isBatPlaying;
    private static bool _isBunnyPlaying;
    private static bool _isDuckPlaying;
    private static bool _isChickenPlaying;
    private static bool _aiBat;
    private static bool _aiBunny;
    private static bool _aiDuck;
    private static bool _aiChicken;

    public PreSettings() {
        
    }

    public bool IsBatPlaying {
        get => _isBatPlaying;
        set => _isBatPlaying = value;
    }

    public bool IsBunnyPlaying {
        get => _isBunnyPlaying;
        set => _isBunnyPlaying = value;
    }

    public bool IsDuckPlaying {
        get => _isDuckPlaying;
        set => _isDuckPlaying = value;
    }

    public bool IsChickenPlaying {
        get => _isChickenPlaying;
        set => _isChickenPlaying = value;
    }

    public bool IsAIBat {
        get => _aiBat;
        set => _aiBat = value;
    }

    public bool IsAIBunny {
        get => _aiBunny;
        set => _aiBunny = value;
    }

    public bool IsAIDuck {
        get => _aiDuck;
        set => _aiDuck = value;
    }

    public bool IsAIChicken {
        get => _aiChicken;
        set => _aiChicken = value;
    }
}
