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
using System.Collections.Generic;

namespace Rage.Shaders.Values {
    public class ValueList : Value, IList<Value> {

        private List<Value> list;

        public ValueList() {
            list = new List<Value>();
        }

        public ValueList(int count) {
            list = new List<Value>(count);
        }

        public ValueList( Value[] array ) {
            list = new List<Value>( array );
        }

        #region IList<ShaderParameter> Members

        public int IndexOf( Value item ) {
            return list.IndexOf( item );
        }

        public void Insert( int index, Value item ) {
            list.Insert( index, item );
        }

        public void RemoveAt( int index ) {
            list.RemoveAt( index );
        }

        public Value this[int index] {
            get {
                return list[index];
            }
            set {
                list[index] = value;
            }
        }
        #endregion

        #region ICollection<ParameterValue> Members

        public void Add( Value item ) {
            list.Add( item );
        }

        public void Clear() {
            list.Clear();
        }

        public bool Contains( Value item ) {
            return list.Contains( item );
        }

        public void CopyTo( Value[] array, int arrayIndex ) {
            list.CopyTo( array, arrayIndex );
        }

        public int Count {
            get { return list.Count; }
        }

        [System.ComponentModel.Browsable(false)]
        public bool IsReadOnly {
            get { return false; }
        }

        public bool Remove( Value item ) {
            return list.Remove( item );
        }

        #endregion

        #region IEnumerable<ShaderParameter> Members

        public IEnumerator<Value> GetEnumerator() {
            return list.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return list.GetEnumerator();
        }

        #endregion
    }
}
