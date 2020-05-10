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

namespace Rage.Shaders.Values
{
    [System.ComponentModel.TypeConverter( typeof( System.ComponentModel.ExpandableObjectConverter ) )]
    public class ValueFloat4x4 : Value
    {
        public float M11 { get; private set; }
        public float M12 { get; private set; }
        public float M13 { get; private set; }
        public float M14 { get; private set; }

        public float M21 { get; private set; }
        public float M22 { get; private set; }
        public float M23 { get; private set; }
        public float M24 { get; private set; }

        public float M31 { get; private set; }
        public float M32 { get; private set; }
        public float M33 { get; private set; }
        public float M34 { get; private set; }

        public float M41 { get; private set; }
        public float M42 { get; private set; }
        public float M43 { get; private set; }
        public float M44 { get; private set; }

        public ValueFloat4x4( BinaryReader br ) {
            Read(br);
        }

        public void Read(BinaryReader br) {
            M11 = br.ReadSingle();
            M12 = br.ReadSingle();
            M13 = br.ReadSingle();
            M14 = br.ReadSingle();

            M21 = br.ReadSingle();
            M22 = br.ReadSingle();
            M23 = br.ReadSingle();
            M24 = br.ReadSingle();

            M31 = br.ReadSingle();
            M32 = br.ReadSingle();
            M33 = br.ReadSingle();
            M34 = br.ReadSingle();

            M41 = br.ReadSingle();
            M42 = br.ReadSingle();
            M43 = br.ReadSingle();
            M44 = br.ReadSingle();
        }

        public override string ToString() {
            return "float4x4";
        }
    }
}
