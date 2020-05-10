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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Rage.Shaders
{
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class Technique
    {
        private ShaderDictionary parent;
        public string Name { get; private set; }
        public Pass[] Passes { get; private set; }

        public Technique(BinaryReader br, ShaderDictionary parent) {
            this.parent = parent;
            Read(br);
        }

        public void Read(BinaryReader br) {
            Name = Utils.ReadString(br);
            byte passesCount = br.ReadByte();

            if (passesCount > 0)
            {
                Passes = new Pass[passesCount];
                for (int i = 0; i < passesCount; i++) {
                    Passes[i] = new Pass(br, parent);
                }                
            }
        }
        public override string ToString()
        {
            string retValue = Name;
            if (Passes != null) retValue += " (" + Passes.Length.ToString() + " Passes)";
            return retValue;
        }
    }
}
