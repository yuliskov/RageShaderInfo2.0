﻿/**********************************************************************\

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
    public class ValueInt : Value
    {
        public int value { get; private set; }

        public ValueInt(BinaryReader br) {
            Read(br);
        }

        public void Read(BinaryReader br) {
            value = br.ReadInt32();
        }

        public override string ToString() {
            return "int";
        }
    }
}
