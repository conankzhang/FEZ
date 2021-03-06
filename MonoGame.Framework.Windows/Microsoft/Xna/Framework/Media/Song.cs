﻿// Type: Microsoft.Xna.Framework.Media.Song
// Assembly: MonoGame.Framework.Windows, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D2107839-320D-467B-B82A-28CB452CC584
// Assembly location: F:\Program Files (x86)\FEZ\MonoGame.Framework.Windows.dll

using Microsoft.Xna.Framework.Audio;
using System;
using System.IO;

namespace Microsoft.Xna.Framework.Media
{
  public sealed class Song : IEquatable<Song>, IDisposable
  {
    private int _playCount = 0;
    private SoundEffectInstance _sound;
    private string _name;
    private bool disposed;

    public string FilePath
    {
      get
      {
        return this._name;
      }
    }

    internal float Volume
    {
      get
      {
        if (this._sound != null)
          return this._sound.Volume;
        else
          return 0.0f;
      }
      set
      {
        if (this._sound == null || (double) this._sound.Volume == (double) value)
          return;
        this._sound.Volume = value;
      }
    }

    public TimeSpan Duration
    {
      get
      {
        return new TimeSpan(0L);
      }
    }

    public TimeSpan Position
    {
      get
      {
        return new TimeSpan(0L);
      }
    }

    public bool IsProtected
    {
      get
      {
        return false;
      }
    }

    public bool IsRated
    {
      get
      {
        return false;
      }
    }

    public string Name
    {
      get
      {
        return Path.GetFileNameWithoutExtension(this._name);
      }
    }

    public int PlayCount
    {
      get
      {
        return this._playCount;
      }
    }

    public int Rating
    {
      get
      {
        return 0;
      }
    }

    public int TrackNumber
    {
      get
      {
        return 0;
      }
    }

    private event Song.FinishedPlayingHandler DonePlaying;

    internal Song(string fileName)
    {
      this._name = fileName;
      this._sound = new SoundEffect(this._name).CreateInstance(false);
    }

    ~Song()
    {
      this.Dispose(false);
    }

    public static bool operator ==(Song song1, Song song2)
    {
      if (song1 == null)
        return song2 == null;
      else
        return song1.Equals(song2);
    }

    public static bool operator !=(Song song1, Song song2)
    {
      return !(song1 == song2);
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    private void Dispose(bool disposing)
    {
      if (this.disposed)
        return;
      if (disposing && this._sound != null)
      {
        this._sound.Dispose();
        this._sound = (SoundEffectInstance) null;
      }
      this.disposed = true;
    }

    public bool Equals(Song song)
    {
      return song != null && this.Name == song.Name;
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;
      else
        return this.Equals(obj as Song);
    }

    internal void OnFinishedPlaying(object sender, EventArgs args)
    {
      if (this.DonePlaying == null)
        return;
      this.DonePlaying(sender, args);
    }

    internal void SetEventHandler(Song.FinishedPlayingHandler handler)
    {
      if (this.DonePlaying != null)
        return;
      this.DonePlaying += handler;
    }

    internal void Play()
    {
      if (this._sound == null)
        return;
      this._sound.Play();
      ++this._playCount;
    }

    internal void Resume()
    {
      if (this._sound == null)
        return;
      this._sound.Resume();
    }

    internal void Pause()
    {
      if (this._sound == null)
        return;
      this._sound.Pause();
    }

    internal void Stop()
    {
      if (this._sound == null)
        return;
      this._sound.Stop(false);
      this._playCount = 0;
    }

    internal delegate void FinishedPlayingHandler(object sender, EventArgs args);
  }
}
