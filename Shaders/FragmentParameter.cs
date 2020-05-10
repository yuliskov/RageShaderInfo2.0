/**********************************************************************\

 Rage Shader Info
 Copyright (C) 2009  DerPlaya78

 This program is free software: you can redistribute it and/or modify
 it under the terms of the GNU General Public License as published by
 the Free Software Foundation, either version 3 of the License, or
 (at your option) any later version.

 This program is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU General Public License for more details.

 You should have received a copy of the GNU General Public License
 along with this program.  If not, see <http://www.gnu.org/licenses/>.

\**********************************************************************/
using System.IO;

namespace Rage.Shaders {
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class FragmentParameter {
        public enum FragmentRegisterType {
            Temp = 0, // Temporary Register File
            Input = 1, // Input Register File
            Const = 2, // Constant Register File
            Addr = 3, // Address Register (VS)
            Texture = 3, // Texture Register File (PS)
            RastOut = 4, // Rasterizer Register File
            AttrOut = 5, // Attribute Output Register File
            TexCrdOut = 6, // Texture Coordinate Output Register File
            Output = 6, // Output register file for VS3.0+
            ConstInt = 7, // Constant Integer Vector Register File
            ColorOut = 8, // Color Output Register File
            DepthOut = 9, // Depth Output Register File
            Sampler = 10, // Sampler State Register File
            Const2 = 11, // Constant Register File  2048 - 4095
            Const3 = 12, // Constant Register File  4096 - 6143
            Const4 = 13, // Constant Register File  6144 - 8191
            ConstBool = 14, // Constant Boolean register file
            Loop = 15, // Loop counter register file
            TempFloat16 = 16, // 16-bit float temp register file
            MiscType = 17, // Miscellaneous (single) registers.
            Label = 18, // Label
            Predicate = 19  // Predicate register
        }

        [System.ComponentModel.DisplayName("Register Type")]
        public FragmentRegisterType RegisterType { get; private set; }
        [System.ComponentModel.DisplayName("Register Index")]
        public ushort RegisterIndex { get; private set; }
        public string Name { get; private set; }
        [System.ComponentModel.DisplayName("Shader Parameter")]
        public ShaderParameter ShaderParameter { get; private set; }
        [System.ComponentModel.DisplayName("Const = 1, Temp = 2?")]
        public int ShaderParameterListIndex { get; private set; }

        public void SetShaderParameter( ShaderParameter p, int i ) {
            ShaderParameter = p;
            ShaderParameterListIndex = i;
        }

        public FragmentParameter( BinaryReader br ) {
            Read( br );
        }

        public void Read( BinaryReader br ) {
            RegisterType = (FragmentRegisterType) br.ReadUInt16();
            RegisterIndex = br.ReadUInt16();
            Name = Utils.ReadString(br);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
