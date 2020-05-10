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
    public class Utils
    {
        public static string ReadString(BinaryReader br) {
            byte strlen = br.ReadByte();
            byte[] buffer = new byte[strlen];
            br.Read(buffer, 0, strlen);
            return ASCIIEncoding.ASCII.GetString(buffer, 0, strlen - 1);
        }
    }
}
