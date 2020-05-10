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
    public class ValueFloat3 : Value
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Z { get; private set; }

        public ValueFloat3( BinaryReader br ) {
            Read(br);
        }

        public void Read(BinaryReader br) {
            X = br.ReadSingle();
            Y = br.ReadSingle();
            Z = br.ReadSingle();
        }
        public override string ToString() {
            return "float3(" +
                ", " + X.ToString( System.Globalization.CultureInfo.InvariantCulture ) +
                ", " + Y.ToString( System.Globalization.CultureInfo.InvariantCulture ) +
                ", " + Z.ToString( System.Globalization.CultureInfo.InvariantCulture ) +
                ")";
        }
    }
}
