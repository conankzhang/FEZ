﻿// Type: Microsoft.Xna.Framework.Graphics.IEffectLights
// Assembly: MonoGame.Framework, Version=3.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 69677294-4E99-4B9C-B72B-CC2D8AA03B63
// Assembly location: F:\Program Files (x86)\FEZ\MonoGame.Framework.dll

using Microsoft.Xna.Framework;

namespace Microsoft.Xna.Framework.Graphics
{
  public interface IEffectLights
  {
    Vector3 AmbientLightColor { get; set; }

    DirectionalLight DirectionalLight0 { get; }

    DirectionalLight DirectionalLight1 { get; }

    DirectionalLight DirectionalLight2 { get; }

    bool LightingEnabled { get; set; }

    void EnableDefaultLighting();
  }
}
