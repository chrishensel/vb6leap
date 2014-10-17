// This file is part of vb6leap.
// 
// vb6leap is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// vb6leap is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with vb6leap.  If not, see <http://www.gnu.org/licenses/>.

using System.Collections.Generic;
using System.ComponentModel;

namespace VB6leap.Core.Collections
{
    /// <summary>
    /// Default implementation of the <see cref="IPropertyBag"/> interface.
    /// </summary>
    public class PropertyBag : IPropertyBag
    {
        #region Fields

        private IDictionary<string, object> _bag = new Dictionary<string, object>();

        #endregion

        #region Constructors

        public PropertyBag()
        {

        }

        #endregion

        #region IPropertyBag Members

        public T Get<T>(string key, T defaultValue)
        {
            if (_bag.ContainsKey(key))
            {
                return (T)_bag[key];
            }

            return defaultValue;
        }

        public void Set(string key, object value)
        {
            bool isDifferent = false;

            if (_bag.ContainsKey(key))
            {
                if (value != _bag[key])
                {
                    isDifferent = true;
                }
            }

            _bag[key] = value;

            if (isDifferent)
            {
                OnPropertyChanged(key);
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var copy = PropertyChanged;
            if (copy != null)
            {
                copy(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
        
        #region IEnumerable<string> Members

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            return _bag.Keys.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _bag.Keys.GetEnumerator();
        }

        #endregion

    }
}
