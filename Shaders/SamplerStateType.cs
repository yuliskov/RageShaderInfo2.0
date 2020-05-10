using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rage.Shaders
{
    public enum SamplerStateType
    {
        AddressU = 1,       // TextureAddress                   0
        AddressV = 2,       // TextureAddress                   1
        AddressW = 3,       // TextureAddress                   2
        BorderColor = 4,    //  D3DColor                        3
        MagFilter = 5,      // TextureFilterType                4
        MinFilter = 6,      // TextureFilterType                5
        MipFilter = 7,      // TextureFilterType                6
        MipMapLodBias = 8,  //  MIPMAPLODBIAS, default = 0      7
        MaxMipLevel = 9,
        MaxAnisotropy = 10,
        SrgbTexture = 11,
        ElementIndex = 12,
        DMapOffset = 13
    }

    public enum TextureAddress
    {
        Wrap = 1,
        Mirror = 2,
        Clamp = 3,
        Border = 4,
        MirrorOnce = 5
    }

    public enum TextureFilterType
    {
        None = 0,
        Point = 1,
        Linear = 2,
        Anisotropic = 3,
        PyramidalQuad = 6,
        GaussianQuad = 7,
        ConvolutionMono = 8
    }
}
