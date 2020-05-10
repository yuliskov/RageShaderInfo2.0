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
using System;
using System.IO;
using Rage.Shaders.Values;

namespace Rage.Shaders
{
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class Annotation
    {
        public enum AnnotationType { 
            @int,
            @float,
            @string
        }

        public string Name { get; private set; }
        public AnnotationType Type { get; private set; }
        public Value Value { get; private set; }

        public Annotation() { }
        
        public Annotation(BinaryReader br) {
            Read(br);
        }

        public void Read(BinaryReader br) {
            Name = Utils.ReadString(br);
            Type = (AnnotationType)br.ReadByte();

            switch (Type) { 
                case AnnotationType.@int:
                    Value = new ValueInt(br);
                    break;
                case AnnotationType.@float:
                    Value = new ValueFloat(br); 
                    break;
                case AnnotationType.@string:
                    Value = new ValueString(br);
                    break;
                default:
                    throw new Exception("Unknown Annotation Type");
            }
        }

        public override string ToString()
        {
            return Name + " = " + Value.ToString();
        }
    }
}
