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
    public class ValueFloat4x3 : Value
    {
        public float _11 { get; private set; }
        public float _12 { get; private set; }
        public float _13 { get; private set; }

        public float _21 { get; private set; }
        public float _22 { get; private set; }
        public float _23 { get; private set; }

        public float _31 { get; private set; }
        public float _32 { get; private set; }
        public float _33 { get; private set; }

        public float _41 { get; private set; }
        public float _42 { get; private set; }
        public float _43 { get; private set; }

        public ValueFloat4x3( BinaryReader br ) {
            Read(br);
        }

        public void Read(BinaryReader br) {
            _11 = br.ReadSingle();
            _12 = br.ReadSingle();
            _13 = br.ReadSingle();

            _21 = br.ReadSingle();
            _22 = br.ReadSingle();
            _23 = br.ReadSingle();

            _31 = br.ReadSingle();
            _32 = br.ReadSingle();
            _33 = br.ReadSingle();

            _41 = br.ReadSingle();
            _42 = br.ReadSingle();
            _43 = br.ReadSingle();
        }
        public override string ToString() {
            return "float4x3";
        }
    }
}
