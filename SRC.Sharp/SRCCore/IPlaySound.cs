﻿// Copyright (C) 1997-2012 Kei Sakamoto / Inui Tetsuyuki
// 本プログラムはフリーソフトであり、無保証です。
// 本プログラムはGNU General Public License(Ver.3またはそれ以降)が定める条件の下で
// 再頒布または改変することができます。

using SRCCore.Units;
using System;

namespace SRCCore
{
    // 音声再生のインタフェース
    public interface IPlaySound : IDisposable
    {
        BGMStatus BGMStatus { get; }

        void Initialize();

        void Play(int channel, string path, PlaySoundMode mode);

        void Stop(int channel);
    }

    public enum BGMStatus
    {
        Stopped,
        Playing,
    }

    public enum PlaySoundMode
    {
        None,
        Repeat,
    }
}
